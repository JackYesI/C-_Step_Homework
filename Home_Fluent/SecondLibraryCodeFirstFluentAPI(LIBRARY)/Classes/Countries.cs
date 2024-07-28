using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLibraryCodeFirstFluentAPI.Classes
{
    public class Countries
    {
        public Countries()
        {
            City = new HashSet<Cities>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Cities> City { get; set; }
    }
}
