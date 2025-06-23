#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

#endregion

namespace AppGrupotec
{
    internal class App : IExternalApplication
    {

        string AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public Result OnStartup(UIControlledApplication a)
        {

            a.ControlledApplication.DocumentOpened += OnDocumentOpened;
            //Crear una nueva pestana en la cinta de opciones de Revit

            string tabName = "Grupotec";
            
            string AssemblyName = "C:\\Users\\Mila\\AppData\\Roaming\\Autodesk\\Revit\\Addins\\2023\\AppGrupotec.dll";


            try 
            {
                a.CreateRibbonTab(tabName);
            }
            catch (Exception) 
            {
                //Es posible que la pestana ya existe, asi que capturamos la excepcion
            }

            //Crear nombres de paneles en la nueva pestana
            
            string panelNameMediciones = "Mediciones";
            string panelNameModeloyVistas = "Modelos y Vistas";



            //Aqui se crean el panel Mediciones y sus botones
            try
            {
                //Crear un un panel Mediciones
                RibbonPanel panelMediciones = a.CreateRibbonPanel(tabName, panelNameMediciones);

                //Crear boton Codigo de mediciones en el panel mediciones
                PushButtonData BotonMediciones = new PushButtonData("BotónCodigodeMediciones", "Código de Mediciones", AssemblyName, "AppGrupotec.CommandOpenForm");

                PushButton botonCodigoMediciones = panelMediciones.AddItem(BotonMediciones) as PushButton;
                string ImagePath = Rutas.AbsolutePath("measurementCode", "icons8-medida-32.png");

                botonCodigoMediciones.ToolTip = "Código de Mediciones de Puertas, Muros, Tuberias y valvulas";
                botonCodigoMediciones.LongDescription = "Generar código de mediciones";
                botonCodigoMediciones.LargeImage = new BitmapImage(new Uri(ImagePath));
            }
            catch 
            {
                //Es posible que el boton ya exista, asi que capturamos la excepcion 
            }

            //Aqui se crean el panel Modelos y vistas y sus botones
            try
            {
                RibbonPanel panelModelosyVistas = a.CreateRibbonPanel(tabName, panelNameModeloyVistas);

                //Crear boton Codigo de mediciones en el panel mediciones
                PushButtonData BotonEscalaGrafica = new PushButtonData("BotónEscalaGrafica", "Escala Grafica", AssemblyName, "AppGrupotec.EscalaGrafica");

                PushButton botonEscalaGrafica = panelModelosyVistas.AddItem(BotonEscalaGrafica) as PushButton;
                string ImagePath = Rutas.AbsolutePath("EscalaManual", "icono_escala_32x32.png");

                botonEscalaGrafica.ToolTip = "Actualiza escala gráfica";
                botonEscalaGrafica.LongDescription = "Actualiza escala gráfica de los planos en el modelo";
                botonEscalaGrafica.LargeImage = new BitmapImage(new Uri(ImagePath));
            }
            catch
            {
                //Es posible que el boton ya exista, asi que capturamos la excepcion 
            }


            
            return Result.Succeeded;

        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        private void OnDocumentOpened(object sender, Autodesk.Revit.DB.Events.DocumentOpenedEventArgs args)
        {
            Document doc = args.Document;
            string modelName = System.IO.Path.GetFileNameWithoutExtension(doc.PathName);

            // Mostrar ventana gráfica con el nombre del modelo
            TaskDialog.Show("Nombre del Modelo", $"Modelo abierto:\n{modelName}");
        }

    }
}
