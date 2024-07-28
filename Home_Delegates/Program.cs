using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class Program
    {
        delegate void dlg(uint height, ConsoleColor color);

        static void DrawSquare(uint height, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            int i = 0;

            while (true)
            {
                if (i ==  height) break;
                Console.WriteLine(new string('*', (int)height));
                i++;
            }

            Console.ResetColor();
        }
        static void DrawRectangle(uint height, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            int i = 1;

            while (true)
            {
                Console.WriteLine(new string('*', (int)i));
                if (i == height) break;
                i++;
            }

            Console.ResetColor();
        }
        public enum Operation { add, Minus, Div, Mult }
        public class Calculation
        {
            Func<double, double, double> Func;
            void setCalculation(Operation operation)
            {
                if (operation == Operation.add)
                {
                    Func = (x, y) => { return x + y; };
                }
                if (operation == Operation.Minus)
                {
                    Func = (x, y) => { return x - y; };
                }
                if (operation == Operation.Mult)
                {
                    Func = (x, y) => { return x * y; };
                }
                if (operation == Operation.Div)
                {
                    Func = (x, y) => { return x / y; };
                }
            }
            public double DoubleCalculate(double x1, Operation operation, double x2)
            {
                setCalculation(operation);
                return Func(x1, x2);
            }
        }
        static void QuicSort<T>(T[] array,
                 int  left,
                 int  right,
                 Comparison<T> comp)
        {
            T temp;
            int i = left, j = right;
            T pivot = array[(left + right) / 2];

            while (i <= j)
            {
                while (comp(array[j], pivot) < 0) ++i;
                while (comp(array[j], pivot) > 0) --j;

                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i;
                    --j;
                }
            }
            if (j > left)
                QuicSort(array, left, j, comp);
            if (i < right)
                QuicSort(array, i, right, comp);
        }
        public class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public Product(string name, int price)
            {
                Name = name;
                Price = price;
            }

            public override string ToString()
            {
                return $"Product Name is {Name}\t Product Price is {Price}";
            }
        }
        static void Main(string[] args)
        {
            //DrawSquare(3, ConsoleColor.DarkBlue);
            //DrawRectangle(3, ConsoleColor.DarkGreen);

            //dlg Dlg = new dlg(DrawSquare) + DrawRectangle;

            //Dlg(10, ConsoleColor.Red);



            // ex 2

            //Calculation calk = new Calculation();
            //Console.WriteLine($"5 + 2 = {calk.DoubleCalculate(5, Operation.add, 2)}");
            //Console.WriteLine($"5 - 2 = {calk.DoubleCalculate(5, Operation.Minus, 2)}");
            //Console.WriteLine($"5 * 2 = {calk.DoubleCalculate(5, Operation.Mult, 2)}");
            //Console.WriteLine($"5 / 2 = {calk.DoubleCalculate(5, Operation.Div, 2)}");

            // ex 3
            // a)
            string[] arr = new string[] {"hello", "hi", "lemon", "apple" };
            QuicSort<string>(arr, 0, arr.Length - 1, new Comparison<string>((s1, s2) =>  s1.Length.CompareTo(s2.Length) ));

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            // b)
            Product[] product = new Product[] { new Product("lemon", 123),
            new Product("apple", 5),
            new Product("nuts", 100),
            new Product("car", 1000000)};

            QuicSort<Product>(product, 0, product.Length - 1, new Comparison<Product>((p1, p2) => p1.Price.CompareTo(p2.Price)));

            foreach (var item in product)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
