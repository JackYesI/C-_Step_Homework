using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLibraryCodeFirstFluentAPI.Classes
{
    public class Cities
    {
        public Cities()
        {
            Shops = new HashSet<Shops>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual ICollection<Shops> Shops { get; set; }
    }
}
