using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClases
{
    internal class Ellipse :Shape
    {
        int r;
        int R;
        public int get_r() { return r; }
        public int get_R() { return R; }
        public Ellipse(int r, int R) { this.r = r; this.R = R; }
        public override double getArea() { return System.Math.PI * r * R; }
        public override int getPerimeter() { return 1; }
        public override string ToString()
        {
            return base.ToString() + "\n" + $"Area is {this.getArea()}" + "\n" + $"Perument is {this.getPerimeter()}";
        }
    }
}
