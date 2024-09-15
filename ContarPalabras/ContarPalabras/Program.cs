using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ContarPalabras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String CadelaTexto = "si solo es para ver los resultados, con abrir primero la consola y luego ejecutar desde ahi el programa te deberia valer xd (puedes usar subst para hacerte una unidad virtual con la carpeta del programa)";

            var Cadena2 = Regex.Replace(CadelaTexto.ToLower(), "[^a-z0-9]"," ").Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

           

            Dictionary<string, int> ContadorPalabras = new Dictionary<string, int>();

            foreach (var Cadena in Cadena2) 
            {
                if (ContadorPalabras.ContainsKey(Cadena))
                {
                    ContadorPalabras[Cadena]++;
                }
                else 
                {
                    ContadorPalabras.Add(Cadena, 1);
                }
            }

            foreach (var Cadena in ContadorPalabras)
            {
                Console.WriteLine(@"{0}:{1}", Cadena.Key, Cadena.Value);
            }

        }
    }
}
