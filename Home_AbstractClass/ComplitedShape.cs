using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClases
{
    internal class ComplitedShape : Shape
    {
        Shape[] shapes;
        public ComplitedShape(params Shape[] shapes)
        {
            this.shapes = shapes;
        }
        public override double getArea()
        {
            Console.WriteLine("Enter index shapes");
            int index = int.Parse(Console.ReadLine());
            try
            {
                if (!(index >= 0 && index <= shapes.Length)) {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("Enter number");
                return -1;
            }
            return shapes[index].getArea();
        }
        public override int getPerimeter()
        {
            Console.WriteLine("Enter index shapes");
            int index = int.Parse(Console.ReadLine());
            try
            {
                if (!(index >= 0 && index <= shapes.Length))
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("Enter number");
                return -1;
            }
            return shapes[index].getPerimeter();
        }
        public override string ToString()
        {
            Console.WriteLine("Enter index shapes");
            int index = int.Parse(Console.ReadLine());
            try
            {
                if (!(index >= 0 && index <= shapes.Length))
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("Enter number");
                return "NoString";
            }
            return shapes[index].ToString();
        }
        public void printAllShapes()
        {
            foreach (var item in shapes)
            {
                Console.WriteLine(item.ToString() + "\n");
            }
        }
    }
}
