#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;

#endregion

namespace MisApps
{
    internal class App : IExternalApplication
    {
        
        public Result OnStartup(UIControlledApplication a)
        {
            string AssamblyName = System.Reflection.Assembly.GetExecutingAssembly().Location;

            RibbonPanel panel = a.CreateRibbonPanel("Mi primera aplicación");

            PushButtonData ButtonSaludar = new PushButtonData("Button1", "Saludo inicio", AssamblyName, "MisApps.Saludar");

            PushButton button1 = panel.AddItem(ButtonSaludar) as PushButton;

            button1.ToolTip = "Saludoi de inicio";
            button1.LongDescription = "Sa";

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
