using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Alejandro241126
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Entre la cantidad de numero repetidos");
            //Console.ReadLine();
            long k = 3;

            //int[] numbers = { 10, 5, 5, 4, 5, 5, 5 };

            int[] numbers1 = { 6, 4, 6, 3, 3, 4, 8 ,5 };

            //Console.WriteLine(ConsecutiveNumber(numbers, 1, 3));                    

            //Console.WriteLine(ElementRepeated(numbers, k));


            Console.ReadLine(); 
        }

        static bool ElementRepeated(int[] array, long k)
        {

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] == array[i - 1] && ConsecutiveNumber(array, k, i))
                {
                    return true;
                }

            }
            return false;

        }

        static bool ConsecutiveNumber(int[] array ,long k,long starNumber)
        {
            for (long i = starNumber; i<=starNumber+k-2; i++)
            {
                if (array[i-1] != array[i]) 
                {
                    return false;
                } 
            }
            return true;
        }
    }
}
