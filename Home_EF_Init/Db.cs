using Inicializatory.Classes;
using Inicializatory.Inicialization;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace Inicializatory
{
    public class Db : DbContext
    {
       
        public Db()
            : base("name=Db_Inicialisation")
        {
            Base_Init base_Init = new Base_Init();
            base_Init.InitializeDatabase(this);
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<Alboms> Alboms { get; set; }
        public virtual DbSet<Musics> Musics { get; set; }
        public virtual DbSet<Playlists> Playlists { get; set; }

        public void CreatePlaylist(string genreName)
        {
            var musicList = this.Genre.Where(g => g.Name == genreName).SelectMany(g => g.alboms.SelectMany(a => a.musics)) .ToList();


            var playlist = new Playlists { Name = "First_Playlist", CategoryId = 1 };
            playlist.musics = musicList;

            this.Playlists.Add(playlist);
            this.SaveChanges();
        }
    }

    
}