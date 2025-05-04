#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

#endregion

//if exist "$(AppData)\Autodesk\REVIT\Addins\2023" copy "$(ProjectDir)*.addin" "$(AppData)\Autodesk\REVIT\Addins\2023"
//if exist "$(AppData)\Autodesk\REVIT\Addins\2023" copy "$(ProjectDir)$(OutputPath)*.dll" "$(AppData)\Autodesk\REVIT\Addins\2023"

namespace CodigoMediciones
{
    internal class App : IExternalApplication
    {
        string AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().Location;
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

            try
            {
                RibbonPanel panel = a.CreateRibbonPanel(tabName, panelName);
            }
            catch
            {
                //Es posible que el boton ya exista, asi que capturamos la excepcion 
            }

            

            //Crear un boton en el panel            

            PushButtonData BotonMediciones = new PushButtonData("Botón1", "Código de Mediciones", AssemblyName, "CodigoMediciones.CommandTest");

            PushButton boton1 = panel.AddItem(BotonMediciones) as PushButton;
            string ImagePath = Rutas.AbsolutePath("icons8-medida-32.png");

            boton1.ToolTip = "Código de Mediciones";
            boton1.LongDescription = "Generar código de mediciones";
            boton1.LargeImage = new BitmapImage(new Uri(ImagePath));
            return Result.Succeeded;
        }
        public string AbsolutePath(string folder, string archive)
        {

            string userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string specialFolderPath = Path.Combine(userDocuments, folder, archive);

            return specialFolderPath;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
