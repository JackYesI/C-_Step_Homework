using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLibraryCodeFirstFluentAPI.Classes
{
    public class Shops
    {
        public Shops()
        {
            Products = new HashSet<Products>();
            Workers = new HashSet<Workers>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int CityId { get; set; } 
        public int? ParckingArea { get; set; }
        public virtual Cities Cities { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public virtual ICollection<Workers> Workers { get; set; }
    }
}
