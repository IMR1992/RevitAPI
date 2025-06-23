#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media.Media3D;


#endregion

namespace AppGrupotec
{
    [Transaction(TransactionMode.Manual)]
    public class EscalaGrafica : IExternalCommand
    {
        
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;


            // Retrieve elements from database


            int contPlanos = 0;
            int contParam = 0;

            #region Obtencion de FamilySymbol

            Dictionary<string, FamilySymbol> dictionarySymbol = new Dictionary<string, FamilySymbol>();
            
            //Obtener escalas permitidas
            string filePathEscalas = Rutas.AbsolutePath("EscalaManual", "Escalas.txt");

            List<string> ListEscalas = new List<string>();

            
            try
            {
                //Comprueba si existe el archivo
                if (File.Exists(filePathEscalas))
                {

                    string contenido = "";
                    //Lee el archivo txt
                    using (StreamReader sr = File.OpenText(filePathEscalas))
                    {
                        string s = "";

                        while ((s = sr.ReadLine()) != null)
                        {
                            contenido += s;
                        }
                        //TaskDialog.Show("P1", contenido);

                    }
                    //Divide el string en lista
                    ListEscalas = new List<string>(contenido.Split(',', '\t'));

                }
                //Sino existe toma las escalas siguentes
                else
                {
                    ListEscalas.AddRange(new[] { "1_10", "1_20", "1_50", "1_100", "1_150", "1_200", "1_250", "1_300", "1_500", "1_800", "1_1000", "SinEscala"});
                }
            }
            //Obtiene el error
            catch (Exception ex)
            {
                TaskDialog.Show("Error", ex.ToString());

            }

            //Obtener todas las familyInstans
            List<Element> familySymbol = new List<Element>();

            FilteredElementCollector collectorSym = new FilteredElementCollector(doc);

            collectorSym.OfClass(typeof(FamilySymbol));

            foreach (string escale in ListEscalas)
            {
                //Obtenga el identificador de elemento para el símbolo de familia que se utilizará para encontrar instancias de familia
                
                var query = from element in collectorSym where element.Name == escale select element;
                               

                List<Element> famSyms = query.ToList<Element>();
                              


                if (famSyms.Count == 0) continue;
                else
                {       
                    FamilySymbol familyInstanceSymbol1 = (FamilySymbol)famSyms.FirstOrDefault();

                    if (escale == "SinEscala")
                    {
                        dictionarySymbol.Add("VARIAS", familyInstanceSymbol1);
                        dictionarySymbol.Add("SinEscala", familyInstanceSymbol1);                        
                    }
                    else
                    {                               
                        dictionarySymbol.Add(escale, familyInstanceSymbol1);
                    }
                }

            }
            #endregion 



            //Colector de todos los cuadros de rotulacion
            FilteredElementCollector sheetCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Sheets).OfClass(typeof(ViewSheet));


            // Convertir colector en lista

            List<ViewSheet> sheet = new List<ViewSheet>();            

            foreach (ViewSheet v in sheetCollector.Cast<ViewSheet>())
            { 
                if (v.Name != "Formato_Inicio") sheet.Add(v);
            }

            //Comprobar si hay planos en el modelo
            if (sheet.Count == 0) TaskDialog.Show("Error", "No se encontraron Planos");

            //Comprobar si hay familySymbol en el modelo
            else if (dictionarySymbol.Count == 0)
            {
                TaskDialog.Show("Error", "No existen simbolos de anotacion en el modelo");
                
            }
           
            //Comprobar si existe el parametro CodigoMediciones

            else if (sheet[0].LookupParameter("EscalaManual") == null) 
            {
                TaskDialog.Show("Error", "No existen el parametro EscalaManual");
            }
            
            else
            {
                //Crear listas
                List<string> scalesSheet = new List<string>();

                //Recorrer cada plano
                foreach (ViewSheet v in sheet)
                {
                    //Obtener listado de los Id de las vistas por cada plano
                    ISet<ElementId> iViewIds = v.GetAllPlacedViews();

                    //Convertir ISet de Ids en List de vistas

                    List<Autodesk.Revit.DB.View> views = GetViewsFromIds(iViewIds, doc);

                    //Sino tiene vistas escribe sin escala
                    if (views == null || views.Count == 0) scalesSheet.Add("SIN ESCALA");

                    //Si tiene una sola vista llama al metodo para una sola vista
                    else if (iViewIds.Count == 1) scalesSheet.Add(GetScaleFromView(views[0]));

                    //Si tiene mas de una vista llama al metodo para mas de una vista
                    else scalesSheet.Add(GetScaleFromViews(views));


                }


                for (int i = 0; i < sheet.Count(); i++)
                {
                    FamilySymbol famySymbol;

                    FilteredElementCollector collector = new FilteredElementCollector(doc, sheet[i].Id);
                    collector.OfCategory(BuiltInCategory.OST_TitleBlocks).OfClass(typeof(FamilyInstance)).ToElements();

                    FamilyInstance titleBlock = collector.FirstElement() as FamilyInstance;


                    if (dictionarySymbol.TryGetValue(scalesSheet[i], out famySymbol))
                    {
                       

                        if (titleBlock.Name != "Formato_Inicio")
                        {
                            ++contPlanos;
                            ++contParam;

                            Parameter EscalaManualParametertitleBlock = titleBlock.LookupParameter("EscalaGrafica");

                            Parameter EscalaManualParametersheet = sheet[i].LookupParameter("EscalaManual");

                            //Escribir nuevo vamos de CodigoMediciones

                            using (Transaction tran = new Transaction(doc, "Escribir Escala Manual"))
                            {
                                tran.Start();
                                EscalaManualParametertitleBlock.Set(famySymbol.Id);
                                EscalaManualParametersheet.Set(scalesSheet[i].Replace("_", ":"));
                                tran.Commit();
                            }
                        }
                    }
                    else
                    {
                       

                        using (Transaction tran = new Transaction(doc, "Escribir Escala Manual"))
                        {
                            TaskDialog.Show("Error", titleBlock.Name);
                            if (titleBlock.Name != "Formato_Inicio")
                            {
                                ++contPlanos;
                                ++contParam;

                                TaskDialog.Show("Error", titleBlock.Name);
                                Parameter EscalaManualParametertitleBlock = titleBlock.LookupParameter("EscalaGrafica");

                                Parameter EscalaManualParametersheet = sheet[i].LookupParameter("EscalaManual");

                                tran.Start();
                                EscalaManualParametertitleBlock.Set(dictionarySymbol["SinEscala"].Id);
                                EscalaManualParametersheet.Set("Sin Escala");
                                tran.Commit();
                            }
                        }
                    }


                }


                TaskDialog.Show("Finalizado", $"Se han procesado {contPlanos} planos y actualizado {contParam} escalas.");

            }

            return Result.Succeeded;
        }


        #region Metodos
        public List<Autodesk.Revit.DB.View> GetViewsFromIds(ISet<ElementId> viewIds,Document doc)
        {
            List<Autodesk.Revit.DB.View> views = new List<Autodesk.Revit.DB.View>();
            foreach (ElementId vi in viewIds)
            {
                //Convertir elementid en Vista
                if (doc.GetElement(vi) is Autodesk.Revit.DB.View view)
                {
                    views.Add(view);
                }

            }
            return views;
        }



        public string GetScaleFromViews(List<Autodesk.Revit.DB.View> views)
        {
            //De un listado de vistas filtra los no deseados y obtine las escalas. Sino son iguales pone VARIAS
            List<int> scalaTemp = new List<int>();

            foreach (Autodesk.Revit.DB.View view in views)
            {
                
                if (view.ViewType == ViewType.DraftingView && view.Name.ToLower().Contains("escala")) scalaTemp.Add(view.Scale);

                else if (view.ViewType != ViewType.DraftingView && view.ViewType != ViewType.Legend && view.ViewType != ViewType.Detail) scalaTemp.Add(view.Scale);


            }


            //Si todas las escalas de la lista son iguales devuelve la escala sino devuelve VARIAS
            if (scalaTemp.All(x => x == scalaTemp[0]))
            {
                return "1_" + scalaTemp[0];
            }
            else
            {
                return "VARIAS";
            }
        }

        public string GetScaleFromView(Autodesk.Revit.DB.View view)
        {

            //Devuelve la escala sino es una de las vista no deseadas, sino escribe sin escala
            if (view.ViewType == ViewType.DraftingView && view.Name.ToLower().Contains("escala")) return "1_" + view.Scale;

            else if (view.ViewType != ViewType.DraftingView && view.ViewType != ViewType.Legend && view.ViewType != ViewType.Detail && view.ViewType != ViewType.ThreeD) return "1_" + view.Scale;

            else return "SIN ESCALA";
        }

        #endregion

    }
}
