using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicializatory.Classes
{
    public class Alboms
    {
        public Alboms()
        {
            musics = new HashSet<Musics>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public int GenreId { get; set; }
    
        public Genre genre { get; set; }
   
        public Artists artists { get; set; }
        public ICollection<Musics> musics { get; set; }
    }
}
