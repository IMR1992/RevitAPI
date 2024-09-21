using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejandro240917
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[5] { -1, 1, 3, 4, 5 };
            

            //IsUpward(ints);

            Console.WriteLine(ints[0]);

            Rota(ints, 2);

            //Rota2(ints, -2);

            Console.WriteLine(ints[0]);

            //Console.WriteLine(ReverseString("casa"));

            //Console.WriteLine(CompletPalindromo("Casaya"));

            //Console.WriteLine(IsPalindromo("Casac"));

            //Console.WriteLine(IsPalindromo("cala"));

            Console.ReadLine();


        }

        public static bool IsUpward(int[] array) 
        {
            //Implemente un método que determine si el array está ordenado en orden no decreciente

            

            for (int i = 0; i < array.Length - 1;i++)
            {
                if (array[i] > array[i+1]) 
                {
                    return false;
                    
                }
                

            }
            return true;
        }

        public static void Rota(int[] N, int k)
        {

            //Implemente el método void Rota(int[] N, int k) que rote circularmente los elementos
            //de N, k posiciones a la derecha.
            
            int nLong = N.Length;
            
            List<int> list = new List<int>();

            for (int i = k; i < N.Length; i++) 
            {
                list.Add(N[i]);
            }

            for (int i = 0; i < k; i++) 
            {
                list.Add(N[i]);
            }

            for(int i = 0; i < nLong ; i++) N[i] = list[i];

        }

        public static void Rota2(int[] N, int k)
        {

            //Implemente el método void Rota(int[] N, int k) que rote circularmente los elementos
            //de N, k posiciones a la derecha.

            if (k > 0)
            {
                Rota(N, k);
            }
            else
            {

                int nLong = N.Length;

                List<int> list = new List<int>();

                for (int i = -k; i < N.Length; i++)
                {
                    list.Add(N[i]);
                }

                for (int i = 0; i < -k; i++)
                {
                    list.Add(N[i]);
                }

                for (int i = 0; i < nLong; i++) N[i] = list[i];



                // N = list.ToArray();

                //Console.WriteLine(N[0]);
            }
        }



        public static string CompletPalindromo(string text) 
        {          

           
            string t = "";

            for (int i = 0; i < text.Length; i++) 
            {
                t = text[i] + t;

                if (IsPalindromo(text + t)) break;                     

            }

            return t.ToLower();
        }

        public static string ReverseString(string Text) 
        {
            char[] Chars = Text.ToCharArray();

            Array.Reverse(Chars);


            string NewText = new string(Chars);

            return NewText;
        }

        public static bool IsPalindromo(string text) 
        {

            text = text.ToLower();
                        
            for (int i = 0; i < text.Length / 2; i++) 
            {
                if (text[i] != text[text.Length - 1 - i]) return false;
            }

            return true;
                         
        }


    }
}
