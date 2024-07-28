using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClases
{
    internal class Diamond : Shape
    {
        private int d1;
        private int d2;
        public int D1 { get { return d1; } }
        public int D2 { get { return d2; } }
        public Diamond(int d1, int d2)
        {
            this.d1 = d1;
            this.d2 = d2;
        }
        public override double getArea()
        {
            return (d1 * d2) / 2;
        }
        public override int getPerimeter()
        {
            return (int)System.Math.Sqrt(System.Math.Pow(d1 / 2, 2) + System.Math.Pow(d2 / 2, 2)) * 4;
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + $"Area is {this.getArea()}" + "\n" + $"Perument is {this.getPerimeter()}";
        }
    }
}
