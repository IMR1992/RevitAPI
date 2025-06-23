using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            int[] ints2 = new int[5] { -1, 1, 3, 4, 5 };

            //Console.WriteLine(OrderiMax(ints)[3]);

            
            

            //IsUpward(ints);

            //Console.WriteLine(ints[0]);

            //Rota(ints, 2);
            //RotaResto(ints2, 2);

            //Console.WriteLine(ints2[0]);
            //Console.WriteLine(ints[3]);

            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] != ints2[i])
                {
                    Console.WriteLine($"Bateo {i} {ints[i]} != {ints2[i]}");
                    break;
                }
            }
            ;

            Console.WriteLine(MaxNum(ints, 2));

            //Rota2(ints, -2);

            //Console.WriteLine(ints[0]);

            //Console.WriteLine(ReverseString("casa"));

            //Console.WriteLine(CompletPalindromo("Casaya"));

            //Console.WriteLine(IsPalindromo("Casac"));

            //Console.WriteLine(IsPalindromo("cala"));

            Console.ReadLine();
        }

        public static int MaxNum(int[] ints , int Num) 
        {
            if ( Num < 0 || Num >= ints.Length  ) return 0;

            return OrderiMax(ints)[Num-1];
        }

        public static int[] OrderiMax(int[] ints) 
        {
            int[] oInts = new int[ints.Length];

            List<int> list =  ints.ToList();

            for (int x = 0; x < ints.Length; x++)
            {
                int max = ints[0];
                

                for (int i = 0; i < list.LongCount(); i++)
                {
                    
                    if (ints[i] >= max)
                    {
                        
                        max = ints[i];
                    }
                }
                
                oInts[x] = max;
                list.Remove(max);

            }


            return oInts;
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

        public static void RotaResto(int[] N, int k)
        {
            int[] P = new int[N.Length];

            for (int i = 0; i < N.Length; i++) 
            {

                int x = N[(i + k) % N.Length];

                P[i] = x;
            }
            for (int i = 0;i < N.Length; i++) N[i] = P[i];
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
