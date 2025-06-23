using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Interop.Excel;
using SpreadsheetLight;
using Excel = Microsoft.Office.Interop.Excel;

namespace FormularioExcel
{

    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();



            List<string> DirectorProyecto = new List<string>();
            List<string> ResponsableTecnico = new List<string>();
            List<string> CoordProyecto = new List<string>();
            List<string> RespMon = new List<string>();
            List<string> SolicitadoPor = new List<string>();
            List<string> NumProyecto = new List<string>();

            //Ruta de acceso excel
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string ruta = @"\OneDrive\Grupotec Servicios Avanzados\O365_GG.00016_AreaBIM_COOR - SeguimientoProyectos\Reparto_Trabajos_Incidencias.xlsx";
            string filePath = basePath + ruta;
            //MessageBox.Show(basePath);

            if (File.Exists(filePath))
            {



                //Crear instancia de SLDocument para abrir el archivo
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook wb = excelApp.Workbooks.Open(filePath);
                Excel._Worksheet worksheet = wb.Sheets[1];
                Excel.Range range = worksheet.UsedRange;
                excelApp.DisplayAlerts = false;

                try
                {


                    //Comprobar que excel esta bien instalado
                    if (excelApp == null)
                    {
                        Console.WriteLine("Excel no esta istalado correctamente");
                    }




                    if (wb == null)
                    {
                        Console.WriteLine("wb no esta istalado correctamente");
                    }

                    if (worksheet == null)
                    {
                        Console.WriteLine("worksheet no esta istalado correctamente");
                    }

                    
                    listasGuardadas(range,3, 2, cbbNumProyecto);
                    //listasGuardadas(range, 3, 3, cbbArea);
                    //listasGuardadas(range, 3, 4, cbbOficina);
                    listasGuardadas(range, 3, 5, cbbDirEncargo);
                    listasGuardadas(range, 3, 6, cbbResTec);
                    listasGuardadas(range, 3, 7, cbbCordProy);
                    listasGuardadas(range, 3, 8, cbbRespMon);
                    listasGuardadas(range, 3, 9, cbbSolicitud);






                    //Obtener fecha
                    DateTime now = DateTime.Now;

                    txtFecha.Text = now.ToShortDateString();



                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error>" + ex.Message);
                }

                finally
                {
                   
                    // Cerrar el libro de trabajo y la aplicación de Excel
                    if (wb != null)
                    {
                        wb.Close(false);
                        Marshal.ReleaseComObject(wb);
                    }

                    if (excelApp != null)
                    {
                        excelApp.Quit();
                        Marshal.ReleaseComObject(excelApp);
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                };
            }
            else MessageBox.Show("No existe el archivo"+filePath);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cbbArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbDirEncargo_SelectedIndexChanged(object sender, EventArgs e)
        {
  

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cerrar aplicacion
            System.Windows.Forms.Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)

        {
            bool check = false;
            if (cbxErrTecnico.Checked || cbxCliente.Checked || cbxErrModelado.Checked || cbxFaltaInf.Checked)
            {
                check= true;
            }
            if (check && cbbNumProyecto.Text != "" && cbbArea.Text != "" && cbbOficina.Text != "" && cbbDirEncargo.Text != "" && cbbResTec.Text != "" && cbbCordProy.Text != "" && cbbRespMon.Text != "" && cbbSolicitud.Text != "" && cbbTipoEntrega.Text != "" && txtNumPlanosEntrega.Text != "" && txtNumPlanosProyecto.Text != "")
                
            {
                    Excel.Application excelApp = null;
                    Excel.Workbook workbook = null;
                    Excel.Worksheet worksheet = null;

                //Ruta de acceso excel
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string ruta = @"\OneDrive\Grupotec Servicios Avanzados\O365_GG.00016_AreaBIM_COOR - SeguimientoProyectos\Reparto_Trabajos_Incidencias.xlsx";
                string filePath = basePath + ruta;

                try
                {
                    // Iniciar la aplicación de Excel
                    excelApp = new Excel.Application();
                    excelApp.DisplayAlerts = false;
                    // Abrir el libro de trabajo
                    workbook = excelApp.Workbooks.Open(filePath);
                    // Obtener la primera hoja de trabajo
                    worksheet = workbook.Sheets[1];

                    //Obtener fecha
                    DateTime now = DateTime.Now;

                    txtFecha.Text = now.ToShortDateString();

                    //Obtener la ultima filacon datos
                    int lastaRow = worksheet.Cells[worksheet.Rows.Count, 1].End(Excel.XlDirection.xlUp).Row;

                   
                    //Escribir nuevas filas
                    worksheet.Cells[lastaRow + 1, 1].Value = lastaRow - 1;
                    worksheet.Cells[lastaRow + 1, 2].Value = cbbNumProyecto.Text;
                    worksheet.Cells[lastaRow + 1, 3].Value = cbbArea.Text;
                    worksheet.Cells[lastaRow + 1, 4].Value = cbbOficina.Text;
                    worksheet.Cells[lastaRow + 1, 5].Value = cbbDirEncargo.Text;
                    worksheet.Cells[lastaRow + 1, 6].Value = cbbResTec.Text;
                    worksheet.Cells[lastaRow + 1, 7].Value = cbbCordProy.Text;
                    worksheet.Cells[lastaRow + 1, 8].Value = cbbRespMon.Text;
                    worksheet.Cells[lastaRow + 1, 9].Value = cbbSolicitud.Text;
                    worksheet.Cells[lastaRow + 1, 10].Value = now.ToShortDateString();
                    worksheet.Cells[lastaRow + 1, 15].Value = dtpFechaEntrega.Text;
                    worksheet.Cells[lastaRow + 1, 16].Value = cbbTipoEntrega.Text;
                    worksheet.Cells[lastaRow + 1, 17].Value = txtNumPlanosEntrega.Text;
                    worksheet.Cells[lastaRow + 1, 18].Value = txtNumPlanosProyecto.Text;
                    worksheet.Cells[lastaRow + 1, 19].Value = txtComentarios.Text;

                    if (cbxCliente.Checked)
                    {
                        worksheet.Cells[lastaRow + 1, 11].Value = "X";
                    }
                    if (cbxFaltaInf.Checked)
                    {
                        worksheet.Cells[lastaRow + 1, 12].Value = "X";
                    }
                    if (cbxErrModelado.Checked)
                    {
                        worksheet.Cells[lastaRow + 1, 13].Value = "X";
                    }
                    if (cbxErrTecnico.Checked)
                    {
                        worksheet.Cells[lastaRow + 1, 14].Value = "X";
                    }
                    MessageBox.Show("La incidencia se guardo con el numero "+( lastaRow - 1));



                    // Guardar los cambios
                    workbook.Save();
                    
                    
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocurrio un error>" + ex.Message);
                    }
                    finally
                    {
                        // Cerrar el libro de trabajo y la aplicación de Excel
                        if (workbook != null)
                        {
                            workbook.Close(false);
                            Marshal.ReleaseComObject(workbook);
                        }
                        if (excelApp != null)
                        {
                            excelApp.Quit();
                            Marshal.ReleaseComObject(excelApp);
                        }
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                //Cerrar aplicacion
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                MessageBox.Show("Rellene todos los campos");
            }
        }

        public void listasGuardadas(Excel.Range rango,int comienzo,int columna,ComboBox comboBox) 
        {
            int rowCount = rango.Rows.Count;
            List<string> lista1 = new List<string>();

            //Crear lista de elementos guardados
            for (int row = comienzo; row <= rowCount; row++)
            {

                var cellValue = (rango.Cells[row, columna] as Excel.Range).Value2;
                lista1.Add(cellValue.ToString());
            }
            //Limpiar lista de elementos repetidos
            HashSet<string> HashClean = new HashSet<string>(lista1);

            //Crear listas nuevas limpias
            List<string> listaClean = new List<string>(HashClean);

            //Autocompletado
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

            //Llenar ComboBox

            foreach (var i in listaClean)
            {
                autoComplete.Add(i.ToString());
                comboBox.Items.Add(i);
            }
            comboBox.AutoCompleteCustomSource = autoComplete;
        }
    }
}
