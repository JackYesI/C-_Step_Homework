using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLibraryCodeFirstFluentAPI.Classes
{
    public class Products
    {
        public Products()
        {
            Shops = new HashSet<Shops>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public int? CategoryId { get; set; }
        public int Quantity { get; set; }
        public bool IsitStock { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual ICollection<Shops> Shops { get; set; }
    }
}
