using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_Index_DB
{
    public class PostalCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public ICollection<Street> Streets { get; set; }
    }
}
