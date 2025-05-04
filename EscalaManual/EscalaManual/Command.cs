#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#endregion

namespace EscalaManual
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        Document doc;
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            doc = uidoc.Document;
           

            // Retrieve elements from database

            string salida = "";
            string prueba = "";


            //Colector de todos los cuadros de rotulacion
            FilteredElementCollector sheetCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Sheets).OfClass(typeof(ViewSheet));
                    
                        
            // Convertir colector en lista

            List<ViewSheet> sheet = new List<ViewSheet>();

            foreach (ViewSheet v in sheetCollector.Cast<ViewSheet>())
            {
                sheet.Add(v);
            }
            //Comprobar si hay planos en el modelo
            if (sheet.Count == 0) TaskDialog.Show("Error", "No se encontraron Planos");

            else
            {
                //Crear listas
                List<int> scalesSheet = new List<int>();

                //Recorrer cada plano
                foreach (ViewSheet v in sheet)
                {
                    //Obtener listado de los Id de las vistas por cada plano
                    ISet<ElementId> iViewIds = v.GetAllPlacedViews();

                    //Obtener escala de cada plano
                    //int scaleSheet = ScaleSheet(iViewIds);
                    List<View> views = GetViewsFromIds(iViewIds);
                    ViewType[] typesToSkip = {ViewType.Detail, ViewType.Legend, ViewType.DraftingView, ViewType.ThreeD};
                    views = SkipViewsByViewType(views, typesToSkip);
                    int scaleSheet = GetScaleFromViews(views);

                    FilteredElementCollector SheetCollector = new FilteredElementCollector(doc, v.Id);
                    List<Element> titleBlocksTmp = SheetCollector.OfClass(typeof(FamilyInstance)).ToElements().ToList();

                    foreach (Element titleBlock in titleBlocksTmp)
                    {
                        prueba += $"{titleBlock.Name.ToString()}\n";
                    }

                    scalesSheet.Add(scaleSheet);
                }






                for (int i = 0;  i < scalesSheet.Count ; i++)
                {
                    salida += $"{sheet[i].SheetNumber.ToString()},{scalesSheet[i]}\n";                    
                }           

                TaskDialog.Show("Hola", prueba);

                TaskDialog.Show("Hola", salida);
                
                TaskDialog.Show("Salida", $"{sheet.Count},{scalesSheet.Count}");

                
            }

            return Result.Succeeded;
        }

        //public int ScaleSheet(ISet<ElementId> viewIds) 
        //{
        //    //Converteir Iset en List
        //    List<ElementId> viewsId = viewIds.ToList();
        //    List<int> views = new List<int>();

        //    if (viewsId.Count == 0)
        //    {
        //        return 0;
        //    }

        //    foreach (ElementId vi in viewsId)
        //    {
        //        //Convertir elementid en Vista

        //        if (doc.GetElement(vi) is View view)
        //        {
        //            //Nos quedamos solo con las vistas en planta y secciones
        //            if (view.ViewType != ViewType.Detail && view.ViewType != ViewType.Legend && view.ViewType != ViewType.DraftingView && view.ViewType != ViewType.ThreeD)
        //            {
        //                views.Add(view.Scale);
        //            }

        //        }

        //    }
        //    if (views.Count > 0)
        //    {
        //        //Comprobar si todos los elemntos son iguales al primer elemento de la lista
        //        bool todosIguales = views.All(x => x == views[0]);

        //        if (todosIguales)
        //        {
        //            return views[0];
        //        }
        //    }
        //    return 0;
        //}

        public List<View> GetViewsFromIds(ISet<ElementId> viewIds)
        {
            List<View> views = new List<View>();
            foreach (ElementId vi in viewIds)
            {
                //Convertir elementid en Vista
                if (doc.GetElement(vi) is View view)
                {
                    views.Add(view);
                }

            }
            return views;
        }

        public List<View> SkipViewsByViewType(List<View> views, ViewType[] viewTypes)
        {
            List<View> filteredViews= new List<View>();
            foreach (View v in views)
            {
                if(!viewTypes.Contains(v.ViewType))
                {
                    filteredViews.Add(v);
                }
            }
            return filteredViews;
        }

        public int GetScaleFromViews(List<View> views) 
        {


            //return views.All(x => x.Scale == views[0].Scale) ? views[0].Scale : 0;
            if (views.All(x => x.Scale == views[0].Scale))
            {
                return views[0].Scale;
            }
            else
            {
                return 0;
            }
        }
    }
}
