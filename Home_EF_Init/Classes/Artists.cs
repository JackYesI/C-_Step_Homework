using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicializatory.Classes
{
    public class Artists
    {
        public Artists()
        {
            alboms = new HashSet<Alboms>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int CountryId { get; set; }
  
        public Country country { get; set; }
        public ICollection<Alboms> alboms { get; set; }
    }
}
