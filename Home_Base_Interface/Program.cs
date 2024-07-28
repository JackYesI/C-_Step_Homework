using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema("adress my cinema 43", 
                new Movie(), 
                new Movie("title", new Director("Dasha", "Konopelko"), "UA", Genre.Drama, 2022, 10),
                new Movie("title_2", new Director("jack", "car"), "AU", Genre.Horror, 2023, 8));
            Console.WriteLine(cinema.ToString());
            cinema.Sort();
            Console.WriteLine("after sort==============================\n");
            Console.WriteLine(cinema.ToString());

            cinema.Sort(new SortByRating());
            Console.WriteLine("after sort rating ==============================\n");
            Console.WriteLine(cinema.ToString());

            cinema.Sort(new SortByYear());
            Console.WriteLine("after sort year ==============================\n");
            Console.WriteLine(cinema.ToString());

        }
    }
}
