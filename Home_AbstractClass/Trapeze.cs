using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClases
{
    internal class Trapeze : Shape
    {
        int a;
        int b;
        double angleLeft;
        double angleRight;
        int h;
        public int A { get { return a; } }
        public int B { get { return b; } }
        public int H { get { return h; } }
        public double AngleLeft { get { return angleLeft; } }
        public double AngleRight { get { return angleRight; } }
        public Trapeze(int a, int b, double angleLeft, double angleRight)
        {
            this.a = a;
            this.b = b;
            this.angleLeft = System.Math.Sin(angleLeft);
            this.angleRight = System.Math.Sin(angleRight);
        }
        public override double getArea()
        {
            return ((a + b) / 2) * h;
        }
        public override int getPerimeter()
        {
            int c = (int)(h / angleLeft);
            int d = (int)(h / angleRight);
            return a + b + c + d;
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + $"Area is {this.getArea()}" + "\n" + $"Perument is {this.getPerimeter()}";
        }
    }
}
