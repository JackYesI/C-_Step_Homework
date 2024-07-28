using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLibraryCodeFirstFluentAPI.Classes
{
    public class Positions
    {
        public Positions()
        {
            Workers = new HashSet<Workers>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Workers> Workers { get; set; }
    }
}
