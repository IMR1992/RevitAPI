using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ExpresionesEquilibradas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
            * Crea un programa que comprueba si los paréntesis, llaves y corchetes
            * de una expresión están equilibrados.
            * - Equilibrado significa que estos delimitadores se abren y cieran
            *   en orden y de forma correcta.
            * - Paréntesis, llaves y corchetes son igual de prioritarios.
            *   No hay uno más importante que otro.
            * - Expresión balanceada: { [ a * ( c + d ) ] - 5 }
            * - Expresión no balanceada: { a * ( c + d ) ] - 5 }
            */

            var Expresion1 = "{ [ a * ( c + d ) ] - 5 }";
            string Expresion2 = "{ a * ( c + d ) ] - 5 }";

            var symbols = new Dictionary<char, char>
        {
            { '{', '}' },
            { '[', ']' },
            { '(', ')' }
        };

            
            var stack = new Stack<char>();

            int largo = Expresion1.Length;

            for(int i = 0; i < largo; i++) 
            {
                if (symbols.ContainsKey(Expresion1[i])) 
                {
                    stack.Push(Expresion1[i]);
                }


              
            }
        }
    }
}
