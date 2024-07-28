using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterfaces
{
    class SortByRating : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Movie && y is Movie)
            {
                return (x as Movie).Rating.CompareTo((y as Movie).Rating);
            }
            throw new NotImplementedException();
        }
    }
}
