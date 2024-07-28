using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicializatory.Classes
{
    public class Musics
    {
        public Musics()
        {
            playlists = new HashSet<Playlists>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Duration { get; set; }
        [Required]
        public int AlbomId { get; set; }

        public Alboms albom { get; set; }
        public ICollection<Playlists> playlists { get; set; }
       
    }
}
