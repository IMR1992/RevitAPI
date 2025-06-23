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
    public class CodigoPuertas : IExternalCommand
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

            

            // Obtener Puertas

            var walls = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Doors);

            // Obtener diameter                       
            List<string> listOut = new List<string>();
           

            
            foreach (Element element in walls)

            {
               
                //Obtener Tipo de elemento
                listOut.Add(element.Name);
                ElementType elementType = doc.GetElement(element.GetTypeId()) as ElementType;

               
                if (elementType!=null)                    
                
                {
                    //Obtener parametros de Tipo
                    Parameter CodigoMontaje = elementType.LookupParameter("Código de montaje");
                   

                    if (CodigoMontaje != null) 
                    {
                        
                        //Obtener parametros de elemento
                        Parameter CodigoMediciones = element.LookupParameter("CodigoMediciones");

                       
                            //Escribir nuevo parametro de CodigoMediciones

                            using (Transaction tran = new Transaction(doc, "Escribir CodigoMediciones"))
                            {
                                tran.Start();
                                CodigoMediciones.Set(CodigoMontaje.AsValueString());
                                tran.Commit();
                                listOut.Add(CodigoMontaje.AsValueString());

                            }

                        
 

                    }
                   

                }

            }





            
            return Result.Succeeded;
        }

      



        
    }
}
