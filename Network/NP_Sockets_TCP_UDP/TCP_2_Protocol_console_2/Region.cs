using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TCP_2_Protocol_console_SERVER
{
    public class Region
    {
        [Key]
        public int Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Area { get; set; }
    }
}
