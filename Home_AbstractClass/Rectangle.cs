using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClases
{
    internal class Rectangle : Shape
    {
        private int a;
        private int b;
        public int A { get { return a; } }
        public int B { get { return b; } }
        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public override double getArea()
        {
            return a * b;
        }
        public override int getPerimeter()
        {
            return a * 2 + b * 2;
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + $"Area is {this.getArea()}" + "\n" + $"Perument is {this.getPerimeter()}";
        }
    }
}
