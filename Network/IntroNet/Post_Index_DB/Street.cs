using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_Index_DB
{
    public class Street
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostalCodeId { get; set; }
        public PostalCode PostalCode { get; set; }
    }
}
