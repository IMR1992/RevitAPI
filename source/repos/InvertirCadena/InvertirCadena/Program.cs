using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvertirCadena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String MiCadena = "Hola Mundo";

            int LargoCadena = MiCadena.Length;

            String NewString = "";

            int i = LargoCadena - 1;

            while(i >= 0)
            {   
                NewString += MiCadena[i];
                i--;

            }
            Console.WriteLine(NewString);
        }
    }
}
