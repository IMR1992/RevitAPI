using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RetosProgramacionEjercicios
{

    /*
     * Crea una única función (importante que sólo sea una) que sea capaz
     * de calcular y retornar el área de un polígono.
     * - La función recibirá por parámetro sólo UN polígono a la vez.
     * - Los polígonos soportados serán Triángulo, Cuadrado y Rectángulo.
     * - Imprime el cálculo del área de un polígono de cada tipo.
     */

    interface Polygon 
    {
        double Area();
        void PrintArea();

    }

    public class Triangle : Polygon 
    {
        public Triangle(double b, double height) 
        {
            this.b = b;
            this.height = height;
        }
        public double Area() 
        {
            return this.b * this.height/2;
        }
        public void PrintArea()
        {
            Console.WriteLine($"El area del triangulo es {Area()}");
        }

        private double b;
        private double height;
    }

    public class Rectangle : Polygon
    {
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public double Area()
        {
            return width * length;
        }
        public void PrintArea()
        {
            Console.WriteLine($"El area del rectangulo es {Area()}");

        }

        private double length;
        private double width;
        
    }

    public class Square : Polygon
    {
        public Square(double side)
        {
            this.side = side;
            
        }
        public double Area()
        {
            return side * side;
        }
        public void PrintArea()
        {
            Console.WriteLine($"El area del rectangulo es {Area()}");

        }

        private double side;
       
    }

     




   

   
}
