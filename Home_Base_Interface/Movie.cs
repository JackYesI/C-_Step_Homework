using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterfaces
{
    class Movie : ICloneable, IComparable
    {
        private string title;
        private Director director;
        private string country;
        private Genre genre;
        private int year;
        private short rating;
        public int Year { get { return year; } }
        public short Rating { get { return rating; } }
        public Movie ()
        {
            title = "NoTitle";
            director = new Director("NoFirstName", "NoLastName");
            country = "NoCountry";
            genre = Genre.None;
            year = 0;
            rating = 0;
        }
        public Movie(string title, Director director, string country, Genre genre, int year, short rating)
        {
            this.title = title;
            this.director = director;
            this.country = country;
            this.genre = genre;
            this.year = year;
            this.rating = rating;
        }
        public object Clone()
        {
            return new Movie(title, director, country, genre, year, rating);
        }
        public int CompareTo(object obj)
        {
            if (obj is Movie)
            {
                return genre.CompareTo(((Movie)obj).genre);
            }
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"Title {title}\n{director.ToString()}\nrating {rating}\nyear {year}\n";
        }
    }

}
