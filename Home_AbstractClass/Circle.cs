using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClases
{
    internal class Circle : Shape
    {
        int r;
        public const double PI = System.Math.PI;
        public int R { get { return r; } }
        public Circle(int r) { this.r = r; }
        public override double getArea()
        {
            return PI * System.Math.Pow(r,2);
        }
        public override int getPerimeter()
        {
            return (int)(2 * PI * r);
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + $"Area is {this.getArea()}" + "\n" + $"Perument is {this.getPerimeter()}";
        }
    }
}
