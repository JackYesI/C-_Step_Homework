using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    enum Category
    {
        eat,
        mahine,
        build,
        joint
    }
    enum Country
    {
        ua,
        pl,
        usa,
        al,
        gr
    }
    internal class Product : IComparable<Product>
    {
        public Country Country { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int CompareTo(Product other)
        {
            return Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"Product Name is {Name,-10} Category is {Category.ToString(),-10} Price is {Price.ToString(), -10} Date is {Date.ToString()}";
        }
    }
}
