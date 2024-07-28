using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterfaces
{
    class SortByYear : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Movie movie&& y is Movie)
            {
                return (x as Movie).Year.CompareTo((y as Movie).Year);
            }
            throw new NotImplementedException();
        }
    }
}
