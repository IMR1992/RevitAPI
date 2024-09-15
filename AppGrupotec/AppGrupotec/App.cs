#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;

#endregion

namespace AppGrupotec
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            //Crear una nueva pestana en la cinta de opciones de Revit

            string tabName = "Grupotec";

            
            try 
            {
                a.CreateRibbonTab(tabName);
            }
            catch (Exception) 
            {
                //Es posible que la pestana ya existe, asi que capturamos la excepcion
            }

            //Crear un un panel en la nueva pestana
            
            string panelName = "Mediciones";

            RibbonPanel panel = a.CreateRibbonPanel(tabName, panelName);

            //Crear un boton en el panel



            return Result.Succeeded;

        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
