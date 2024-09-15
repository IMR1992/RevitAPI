using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetosProgramacionC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
                    /*
         * Crea una única función (importante que sólo sea una) que sea capaz
         * de calcular y retornar el área de un polígono.
         * - La función recibirá por parámetro sólo UN polígono a la vez.
         * - Los polígonos soportados serán Triángulo, Cuadrado y Rectángulo.
         * - Imprime el cálculo del área de un polígono de cada tipo.
         */


            Triangle MiTringulo = new Triangle(2.2, 2.2);            
            MiTringulo.printArea();
            Rectangle MiRectangulo = new Rectangle(2.2, 2.2);
            MiRectangulo.printArea();









        }

       

    }
    interface IPolygon
    {
        double Area();
        void printArea();

    }

    public class Triangle : IPolygon
    {
        public Triangle(double Base, double Altura) 
        {
            this.Base = Base;
            this.Altura = Altura;
        }



        public double Area()
        {
            return Base * Altura / 2;
        }

        public void printArea()
        {
            Console.WriteLine("El area del tringulo es {0}", Area());
        }

        public double Base { get; set; }
        public double Altura { get; set; }

    }
    public class Rectangle : IPolygon
    {
        public Rectangle(double Base, double Altura)
        {
            this.Base = Base;
            this.Altura = Altura;
        }



        public double Area()
        {
            return Base * Altura ;
        }

        public void printArea()
        {
            Console.WriteLine("El area del tringulo es {0}", Area());
        }

        public double Base { get; set; }
        public double Altura { get; set; }

    }
}
