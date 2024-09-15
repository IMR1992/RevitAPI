#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

#endregion

namespace CodigoMediciones
{ 
    [Transaction(TransactionMode.Manual)]
    public class CodigoTuberias : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            //Application app = uiapp.Application;
            Document doc = uidoc.Document;

            string filePathDicionary = Rutas.AbsolutePath("DicTuberias.json");

            string jsonContent = File.ReadAllText(filePathDicionary);

            Dictionary <string,string> dictionaryTuberias = JsonConvert.DeserializeObject<Dictionary<string,string>>(jsonContent);

            List<string> error = new List<string>();
            
            // Obtener Pipes

            var pipes = new FilteredElementCollector(doc).OfClass(typeof(Pipe));

            // Obtener diameter
            List<string> diameters = new List<string>();
            List<string> systems = new List<string>();            
            List<string> codigos = new List<string>();
            

            foreach (Element element in pipes)

            {
                Pipe pipe = element as Pipe;

                Parameter diameterParam = element.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM);      



                string strdiameterMm = "XXX";
                if (diameterParam != null) 
                {
                    
                    double diameter = diameterParam.AsDouble();
                    double diameterMm = Math.Round(diameter * 304.8);
                    if (diameterMm < 10) 
                    {
                        strdiameterMm = "00" + diameterMm.ToString();
                        diameters.Add(strdiameterMm);
                    }
                    else if(diameterMm < 100) 
                    {
                        strdiameterMm = "0" + diameterMm.ToString();
                        diameters.Add(strdiameterMm);
                    }
                    else 
                    {
                        strdiameterMm =diameterMm.ToString();
                        diameters.Add(strdiameterMm);
                    }
                                        
                }
                else 
                {
                    string noDiameter = "XXX";
                    diameters.Add(noDiameter);                
                }

                //Obtrener Tipo de Sistema

                MEPSystem system = pipe.MEPSystem;
                string nameSystem = "Desconocido";

                if (system != null) 
                {
                    Element systemElement = doc.GetElement(system.GetTypeId());
                    if (systemElement != null) 
                    {
                        if (!dictionaryTuberias.TryGetValue(systemElement.Name.Substring(0, 3), out nameSystem))
                        {
                            // Key wasn't in dictionary; "value" is now 0
                            nameSystem = "XXX";
                        }
                        
                    }
                   
                }
               
                
                //Obtener FamilyType

                ElementType elementType = doc.GetElement(element.GetTypeId()) as ElementType;

                //Obtener parametros de elementos
                ParameterSet parametersType = elementType.Parameters;
                string codigoMontaje = "000000000";
                foreach (Parameter parameterT in parametersType) 
                {
                    if (parameterT.Definition.Name == "Código de montaje")
                    {
                        codigoMontaje = parameterT.AsValueString();
                        codigos.Add(codigoMontaje);
                    }
                }
                //Crear codigo de mediciones
                
                string CodigoMediciones = nameSystem + "." + codigoMontaje + strdiameterMm;


                //Encontrar todos los parametros de ejemplar

                ParameterSet parametersElement = element.Parameters;

                //Escribir parametro de codigo de mediciones
                 
                foreach (Parameter parameterE in parametersElement) 
                {                   
                    using (Transaction tran= new Transaction(doc,"Escribir CodigoMediciones"))
                    
                    if (parameterE.Definition.Name == "CodigoMediciones") 
                    {
                            tran.Start();
                        parameterE.Set(CodigoMediciones);
                            tran.Commit();                            

                    }                   

                }
                

            }
            
            return Result.Succeeded;
        }
    }
}
