using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Net.WebRequestMethods;


namespace RetosProgramacionEjercicios
{
    internal class Program
    {
        private static string[] strings;

        static void Main(string[] args)
        {
            //Eje 1
            //FizzBuzz();

            //Eje 2
            //Console.WriteLine(Anagram("hola","aloh"));

            //Eje 3
            //Fibonacci();

            /*Eje 4
            for (int i = 0; i < 100; i++) 
            {
                if (IsPrimo(i)) Console.WriteLine(i);
            }

            //Eje 5
            area(new Triangle(2, 2));
            area(new Triangle(2, 2));
            area(new Triangle(2, 2));
            
            

            //Eje 6

            string url = "https://raw.githubusercontent.com/mouredev/mouredev/master/mouredev_github_profile.png";

            Ratio(url);
            */
            //Eje 7

            Console.WriteLine(Reverse("Hola mundo"));

            //Eje 8


            Console.ReadLine();


            
        }

        public static void FizzBuzz() 
        {
            /*
            * Escribe un programa que muestre por consola (con un print) los
            * números de 1 a 100 (ambos incluidos y con un salto de línea entre
            * cada impresión), sustituyendo los siguientes:
            * - Múltiplos de 3 por la palabra "fizz".
            * - Múltiplos de 5 por la palabra "buzz".
            * - Múltiplos de 3 y de 5 a la vez por la palabra "fizzbuzz".
            */            

            for (int i = 1; i <= 100; i++)
            {
                if (i % 5 == 0 && i % 3==0) 
                {
                    Console.WriteLine("fizzbuzz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("buzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("fizz");
                }
                else
                {
                    Console.WriteLine($"{i.ToString()}");
                }
            }

        }

        public static bool Anagram(string string1,string string2) 
        {

            /*
             * Escribe una función que reciba dos palabras (String) y retorne
             * verdadero o falso (Bool) según sean o no anagramas.
             * - Un Anagrama consiste en formar una palabra reordenando TODAS
             *   las letras de otra palabra inicial.
             * - NO hace falta comprobar que ambas palabras existan.
             * - Dos palabras exactamente iguales no son anagrama.
             */


            string stringOrder1 = new string(string1.ToLower().OrderBy(x => x).ToArray());
            string stringOrder2 = new string(string2.ToLower().OrderBy(x => x).ToArray());
            if (string1.ToLower() == string2.ToLower())
            {
                return false;
            }
            else if (stringOrder1 == stringOrder2)
            {
                return true;
            }
            else return false;


        }

        public static void Fibonacci() 
        {

            /*
             * Escribe un programa que imprima los 50 primeros números de la sucesión
             * de Fibonacci empezando en 0.
             * - La serie Fibonacci se compone por una sucesión de números en
             *   la que el siguiente siempre es la suma de los dos anteriores.
             *   0, 1, 1, 2, 3, 5, 8, 13...
             */

            long a = 0;
            long b = 1;

            for(int i = 0;i <= 50;i++)
            {
                Console.WriteLine(a);
                long c = a + b;
                a = b;
                b = c;
                
            }
        }


        public static bool IsPrimo(int number) 
        {

            /*
             * Escribe un programa que se encargue de comprobar si un número es o no primo.
             * Hecho esto, imprime los números primos entre 1 y 100.
             */
            if (number == 0 || number == 1)return false;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0) return false;
            }

            return true;

            
        }

        public static float Areapoligon(float b , float height) 
        {

            /*
             * Crea una única función (importante que sólo sea una) que sea capaz
             * de calcular y retornar el área de un polígono.
             * - La función recibirá por parámetro sólo UN polígono a la vez.
             * - Los polígonos soportados serán Triángulo, Cuadrado y Rectángulo.
             * - Imprime el cálculo del área de un polígono de cada tipo.
             */




            return 1;
        }

        public static double area(Polygon polygon) 
        {
            polygon.PrintArea();
            return polygon.Area();
        }


        public static async void Ratio(string url) 
        {
            /*
             * Crea un programa que se encargue de calcular el aspect ratio de una
             * imagen a partir de una url.
             * - Url de ejemplo:
             *   https://raw.githubusercontent.com/mouredev/mouredev/master/mouredev_github_profile.png
             * - Por ratio hacemos referencia por ejemplo a los "16:9" de una
             *   imagen de 1920*1080px.
             */
            

            HttpClient client = new HttpClient();

            byte[] imageByte = await client.GetByteArrayAsync(url);

            var ms = new MemoryStream(imageByte);

            Image img = Image.FromStream(ms);

            int width = img.Width;
            int height = img.Height;

            double aspectRatio = (double)width / height;

            Console.WriteLine($"Aspect Ratio:{width}:{height}");
                       
            
        }

        public static string Reverse (string text) 
        {

            /*Eje 7
             * Crea un programa que invierta el orden de una cadena de texto
             * sin usar funciones propias del lenguaje que lo hagan de forma automática.
             * - Si le pasamos "Hola mundo" nos retornaría "odnum aloH"
             */

            string salida = "";
            int textLength = text.Length;
            text.Reverse();
            for (int i = (textLength - 1); i >= 0; i--) 
            {
                salida += text[i].ToString();
            }

            return salida;
        }

        public static int CountWord (string words) 
        {
            //Eje 8
            /*
             * Crea un programa que cuente cuantas veces se repite cada palabra
             * y que muestre el recuento final de todas ellas.
             * - Los signos de puntuación no forman parte de la palabra.
             * - Una palabra es la misma aunque aparezca en mayúsculas y minúsculas.
             * - No se pueden utilizar funciones propias del lenguaje que
             *   lo resuelvan automáticamente.
             */

            int count = 0;

            string minusText =
            
            string[] strings = words.Split(' ');


            //Probando








            return count;
        }






    }
}
