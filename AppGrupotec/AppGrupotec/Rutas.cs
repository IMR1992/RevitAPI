using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGrupotec
{
    internal class Rutas
    {
        public static string 
            AbsolutePath(string carpeta,string archive)
        {
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            string ruta = $@"\AppData\Roaming\Autodesk\Revit\Addins\2023\{carpeta}\{archive}";

            string filePath = basePath + ruta;

            return filePath;
        }
    }
}
