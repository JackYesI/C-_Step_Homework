using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplitedShape shapes = new ComplitedShape(
                new Triangle(3,4,5), 
                new Circle(10), 
                new Diamond(30,40), 
                new Ellipse(5,8), 
                new Parallelogram(20, 30, 30), 
                new Rectangle(5, 6), 
                new Square(10), 
                new Trapeze(20, 30, 30, 100)
                );

            Console.WriteLine(shapes.getArea());
            Console.WriteLine(shapes.ToString());

            Console.WriteLine();

            shapes.printAllShapes();
        }
    }
}
