using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLibraryCodeFirstFluentAPI.Classes
{
    public class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
