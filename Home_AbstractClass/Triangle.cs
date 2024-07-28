using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClases
{
    internal class Triangle : Shape
    {
        private int x;
        private int y;
        private int z;
        private int p;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int Z { get { return z; } }
        public Triangle(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.p = (x + y + z) / 2;
        }
        public override double getArea()
        {
            return System.Math.Sqrt(p * (p - x) * (p - y) * (p - z));
        }
        public override int getPerimeter()
        {
            return p * 2;
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + $"Area is {this.getArea()}" + "\n" + $"Perument is {this.getPerimeter()}";
        }
    }
}
