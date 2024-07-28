using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicializatory.Classes
{
    public class Country
    {
        public Country()
        {
            artists = new HashSet<Artists>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Artists> artists { get; set; }
    }
}
