using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClases
{
    internal class Square : Shape
    {
        private int a;
        public Square(int a) { this.a = a; }
        public int A { get { return a; } }
        public override double getArea()
        {
            return System.Math.Pow(a, 2);
        }
        public override int getPerimeter()
        {
            return 4 * a;
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + $"Area is {this.getArea()}" + "\n" + $"Perument is {this.getPerimeter()}";
        }
    }
}
