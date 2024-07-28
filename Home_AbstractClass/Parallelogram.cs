using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClases
{
    internal class Parallelogram : Shape
    {
        int a;
        int b;
        double angle;
        public int A { get { return a; } }
        public int B { get { return b; } }
        public Parallelogram(int a, int b, int angle)
        {
            this.a = a;
            this.b = b;
            this.angle = System.Math.Sin(angle);
        }
        public override double getArea()
        {
            return a * b * angle;
        }
        public override int getPerimeter()
        {
            return 2 * a + 2 * b;
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + $"Area is {this.getArea()}" + "\n" + $"Perument is {this.getPerimeter()}";
        }
    }
}
