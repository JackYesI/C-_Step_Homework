using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClases
{
    abstract class Shape
    {
        public virtual double getArea()
        {
            return 0;
        }
        public virtual int getPerimeter()
        {
            return 0;
        }

    }
}
