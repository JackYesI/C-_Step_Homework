using Inicializatory.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicializatory.Inicialization
{
    public class Base_Init : DropCreateDatabaseAlways<Db>
    {
        protected override void Seed(Db context)
        {
            if (!context.Country.Any())
            {

                var countries = new List<Country>
            {
                new Country { Name = "Ua" },
                new Country { Name = "Usa" },
                new Country { Name = "Pol" },
                new Country { Name = "Can" },
                new Country { Name = "Ital" },
                new Country { Name = "Por" },
                new Country { Name = "Shc" }
            };
                foreach (var country_ in countries)
                {
                    context.Country.Add(country_);
                }
                context.SaveChanges();
            }
            if (!context.Genre.Any())
            {
                var genres = new List<Genre>
                {
                    new Genre { Name = "Rock" },
                    new Genre { Name = "Metal" },
                    new Genre { Name = "Pop" },
                    new Genre { Name = "DeathCore" },
                    new Genre { Name = "BlackMetal" }
                };
                foreach (var genre in genres)
                {
                    context.Genre.Add(genre);
                }
                context.SaveChanges();
            }
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Category_zero" },
                    new Category { Name = "Category_1" },
                    new Category { Name = "Category_2" }
                };
                foreach (var cat in categories)
                {
                    context.Categories.Add(cat);
                }
                context.SaveChanges();
            }
            if (!context.Artists.Any())
            {
                var artists = new List<Artists>
                {
                    new Artists { Name = "Denys", Surname = "Moss", CountryId = 1 },
                    new Artists { Name = "Olya", Surname = "Redchych", CountryId = 2 },
                    new Artists { Name = "Petro", Surname = "Shy", CountryId = 3 },
                    new Artists { Name = "Dasha", Surname = "Paholyk", CountryId = 4 }
                };
                foreach (var art in artists)
                {
                    context.Artists.Add(art);
                }
                context.SaveChanges();
            }

            if (!context.Alboms.Any())
            {
                var alboms = new List<Alboms>
                {
                    new Alboms { Name = "First_Albom", Year = DateTime.Now.Year, ArtistId = 1, GenreId = 1 },
                    new Alboms { Name = "Second_Albom", Year = DateTime.Now.Year, ArtistId = 2, GenreId = 2 },
                    new Alboms { Name = "Third_Albom", Year = DateTime.Now.Year, ArtistId = 3, GenreId = 3 },
                    new Alboms { Name = "Forth_Albom", Year = DateTime.Now.Year, ArtistId = 4, GenreId = 4 },
                    new Alboms { Name = "Fifth_Albom", Year = DateTime.Now.Year, ArtistId = 1, GenreId = 5 },
                    new Alboms { Name = "Sixth_Albom", Year = DateTime.Now.Year, ArtistId = 2, GenreId = 1 },
                    new Alboms { Name = "Seventh_Albom", Year = DateTime.Now.Year, ArtistId = 3, GenreId = 2 },
                    new Alboms { Name = "Eight_Albom", Year = DateTime.Now.Year, ArtistId = 4, GenreId = 3 },
                    new Alboms { Name = "Ninth_Albom", Year = DateTime.Now.Year, ArtistId = 1, GenreId = 4 }
                };
                foreach (var alb in alboms)
                {
                    context.Alboms.Add(alb);
                }
                context.SaveChanges();
            }

            //if (!context.Playlists.Any())
            //{
            //    var playlists = new List<Playlists>
            //    {
            //        new Playlists { Name = "First_Playlist", CategoryId = 1 },
            //        new Playlists { Name = "Second_Playlist", CategoryId = 2 },
            //        new Playlists { Name = "Thirth_Playlist", CategoryId = 3 },
            //    };
            //    foreach (var play in playlists)
            //    {
            //        context.Playlists.Add(play);
            //    }
            //    context.SaveChanges();
            //}

            if (!context.Musics.Any())
            {
                var musics = new List<Musics>
                {
                    new Musics { Name = "Base", Duration = 3.13, AlbomId = 1 },
                    new Musics { Name = "VEGETA RAGE LOVELY", Duration = 3.02, AlbomId = 9 },
                    new Musics { Name = "TOXIC", Duration = 1.24, AlbomId = 2 },
                    new Musics { Name = "Take it Off", Duration = 1.51, AlbomId = 3 },
                    new Musics { Name = "V-12", Duration = 2.20, AlbomId = 4 },
                    new Musics { Name = "Blinded in Chains", Duration = 6.34, AlbomId = 5 },
                    new Musics { Name = "Blood and Thunder", Duration = 3.49, AlbomId = 6 },
                    new Musics { Name = "One Good Reason", Duration = 3.53, AlbomId = 7 },
                    new Musics { Name = "IMPOSSIBLE", Duration = 3.58, AlbomId = 8 },
                    new Musics { Name = "goku rage for gym pr", Duration = 1.24, AlbomId = 9 },
                    new Musics { Name = "Iconic", Duration = 2.49, AlbomId = 1 },
                    new Musics { Name = "Rocket", Duration = 1.47, AlbomId = 2 },
                    new Musics { Name = "SAY IT RIGHT", Duration = 2.31, AlbomId = 3 },
                    new Musics { Name = "I Took the Red pill but It was just a placebo", Duration = 3.30, AlbomId = 4 },
                    new Musics { Name = "PAPARAZZI HARDSTYLE", Duration = 2.20, AlbomId = 7 },
                    new Musics { Name = "SUPRA STUTUTUTUT", Duration = 2.08, AlbomId = 9 }
                };
                foreach (var muz in musics)
                {
                    context.Musics.Add(muz);
                }
                context.SaveChanges();
            }

              
            
        }
    }
}
