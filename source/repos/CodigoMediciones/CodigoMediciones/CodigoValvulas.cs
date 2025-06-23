#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

#endregion

namespace CodigoMediciones
{
    [Transaction(TransactionMode.Manual)]
    public class CodigoValvulas : IExternalCommand
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


            Dictionary<string, string> dictionaryTuberias = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);



            // Obtener Valvulas

            var AccesoryPipes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeAccessory);

            // Obtener diameter
            List<string> FamilyNames = new List<string>();
            List<Element> valves = new List<Element>();
                        

            //Obtener nombre de familia

            foreach (Element element in AccesoryPipes)

            {
                string FamilyName = element.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
                if (FamilyName.Contains("Valvula")) 
                
                {
                    FamilyInstance valveInstance = element as FamilyInstance;

                    MEPSystem valveSystem = GetValveSystem(valveInstance);
                    string nameSystem = "Desconocido";
                    if (valveSystem != null)
                    {
                        Element systemElement = doc.GetElement(valveSystem.GetTypeId());
                        

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
                    Parameter CodigoMontaje = elementType.LookupParameter("Código de montaje");
                    

                    //Obtener CodigoMaterialValvula
                    Parameter CodigoMaterialValvula = valveInstance.LookupParameter("CodigoMaterialValvula");
                    ;

                    //Obtener CodigoTipoUnionValvula
                    Parameter CodigoTipoUnionValvula = valveInstance.LookupParameter("CodigoTipoUnionValvula");
                    

                    //Crear CodidigoMediciones
                    string ValueCodigoMediciones = nameSystem+"."+CodigoMontaje.AsValueString().Replace("X.XX",(CodigoTipoUnionValvula.AsValueString()+"."+CodigoMaterialValvula.AsValueString()));
                    
                    //Obtener el parametro CodigoMediciones
                    Parameter CodigoMediciones = valveInstance.LookupParameter("CodigoMediciones");

                    //Escribir nuevo vamos de CodigoMediciones
                    
                    using (Transaction tran = new Transaction(doc, "Escribir CodigoMediciones")) 
                    {
                        tran.Start();
                        CodigoMediciones.Set(ValueCodigoMediciones);
                        tran.Commit();
                    }

                    
                   

                }

            }





            
            return Result.Succeeded;
        }

        private static MEPSystem GetValveSystem(FamilyInstance valveInstance)
        {
            // Obtener los conectores de la válvula
            ConnectorSet connectors = valveInstance.MEPModel.ConnectorManager.Connectors;

            foreach (Connector connector in connectors)
            {
                // Verificar si el conector está conectado a un sistema de tuberías
                if (connector.MEPSystem != null)
                {
                    return connector.MEPSystem;
                }
            }



            return null;
        }
    }
}
