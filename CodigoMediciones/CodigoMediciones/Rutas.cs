using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoMediciones
{
    internal class Rutas
    {
        public static string AbsolutePath(string archive)
        {
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            string ruta = $@"\AppData\Roaming\Autodesk\Revit\Addins\2023\measurementCode\{archive}";

            string filePath = basePath + ruta;         

            return filePath;
        }
    }
}
