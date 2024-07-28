using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterfaces
{
    class Cinema : IEnumerable
    {
        private Movie[] movie;
        public string Adress {  get; set; }

        public Cinema(string adress, params Movie[] movie)
        {
            this.Adress = adress;
            this.movie = movie;
        }
        public IEnumerator GetEnumerator()
        {
            return movie.GetEnumerator();
        }
        public void Sort()
        {
            Array.Sort(movie);
        }
        public void Sort(IComparer comparer)
        {
            Array.Sort(movie, comparer);
        }
        public override string ToString()
        {
            string str = $"Adress is {Adress}\n";
            foreach (var item in movie)
            {
                str += item.ToString() + "\n";
            }
            return str;
        }
    }
}
