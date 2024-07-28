using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicializatory.Classes
{
    public class Playlists
    {
        public Playlists()
        {
            musics = new HashSet<Musics>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
    
        public Category category { get; set; }
        public ICollection<Musics> musics { get; set; }
   
    }
}
