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
            

            Console.WriteLine(IsUpward(ints));

            Rota(ints, 2);

            Console.WriteLine(ints[0]);

            //Console.WriteLine(ReverseString("casa"));

            Console.WriteLine(CompletPalindromo("Casa"));

            Console.ReadLine();


        }

        public static bool IsUpward(int[] array) 
        {
            //Implemente un método que determine si el array está ordenado en orden no decreciente

            int back = array[0];

            foreach (int i in array)
            {
                if (back > i) 
                {
                    return false;
                    break;
                }
                back = i;

            }
            return true;
        }

        public static void Rota(int[] N, int k)
        {

            //Implemente el método void Rota(int[] N, int k) que rote circularmente los elementos
            //de N, k posiciones a la derecha.
            
            int Long = N.Length;
            
            List<int> list = new List<int>();

            for (int i = Long-k; i < N.Length; i++) 
            {
                list.Add(N[i]);
            }

            for (int i = 0; i < Long - k; i++) 
            {
                list.Add(N[i]);
            }

            N = list.ToArray();

            Console.WriteLine(N[0]);

        }

        public static string CompletPalindromo(string Text) 
        {
            string NewText = ReverseString(Text);

            int LongText = NewText.Length;

            

            for (int i = 0; i < LongText; i++) 
            {
                string t =ReverseString(Text.Remove(i+1));

                if (IsPalindromo(Text + t)) 
                {
                    return t.ToLower();
                    //break;
                    
                }
            }




            return NewText;
        }

        public static string ReverseString(string Text) 
        {
            char[] Chars = Text.ToCharArray();

            Array.Reverse(Chars);


            string NewText = new string(Chars);

            return NewText;
        }

        public static bool IsPalindromo(string Text) 
        {
            string TextReverse = ReverseString(Text);


            return Text.ToLower() == TextReverse.ToLower(); 
        }


    }
}
