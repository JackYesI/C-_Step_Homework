using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
        {
            new Product { Date = DateTime.Now, Category = Category.eat, Name = "banana", Price = 100, Country = Country.usa},
            new Product { Date = new DateTime(2023, 12, 25), Category = Category.eat, Name = "banana", Price = 100, Country = Country.ua},
            new Product { Date = new DateTime(2023, 3, 3), Category = Category.joint, Name = "kreyi", Price = 150, Country = Country.gr},
            new Product { Date = new DateTime(2023, 6, 2), Category = Category.build, Name = "wood", Price = 800, Country = Country.pl},
            new Product { Date = new DateTime(2024, 7, 3), Category = Category.mahine, Name = "car", Price = 12222, Country = Country.ua},
            new Product { Date = new DateTime(2024, 3, 21), Category = Category.eat, Name = "orenge", Price = 322, Country = Country.al},
            new Product { Date = new DateTime(2023, 3, 22), Category = Category.eat, Name = "salat", Price = 213, Country = Country.ua},
            new Product { Date = new DateTime(2024, 6, 20), Category = Category.eat, Name = "fruit", Price = 312, Country = Country.ua},
            new Product { Date = new DateTime(2023, 7, 12), Category = Category.eat, Name = "mango", Price = 123, Country = Country.ua}
        };
            // ex 1
            //var result = from product in products
            //             where product.Date.Year == DateTime.Now.Year
            //             orderby product.Price descending
            //             select product;
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            // 

            // ex 2
            //var result = from product in products
            //             where product.Country == Country.ua
            //             select product;
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //

            // ex 3
            //Product max = products.OrderByDescending(p => p.Price).First();
            //Product min = products.OrderBy(p => p.Price).First();

            //Console.WriteLine("most expensive " + max.ToString());
            //Console.WriteLine("most cheaper " + min.ToString());
            //

            // ex 4
            //var result = from product in products
            //             where product.Country != Country.ua
            //             select product;
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //

            // ex 5
            //var productCountsByCategory = products.GroupBy(p => p.Category).Select(g => new { Category = g.Key, Count = g.Count() });

            //foreach (var item in productCountsByCategory)
            //{
            //    Console.WriteLine($"Category is {item.Category}: {item.Count}");
            //}
            //

            // ex 6
            var groupedProducts = products.GroupBy(p => p.Category).Select
                (g => new
            {
                Category = g.Key,
                Products = g.OrderBy(p => p.Date).ToList()
            });

            foreach (var item in groupedProducts)
            {
                Console.WriteLine($"Category :: {item.Category}");
                foreach (var item1 in item.Products)
                {
                    Console.WriteLine(item1.ToString());
                }
            }
            //
        }
    }
}
