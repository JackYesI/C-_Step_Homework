using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    public static class DbInitializer
    {
        public static async void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Authors.Any())
            {
                var author = new Author { Name = "Ivan Petrovuch" };
                await context.Authors.AddAsync(author);
                await context.SaveChangesAsync();

                var book = new Book { Title = "main of c#", AuthorId = author.Id };
                await context.Books.AddAsync(book);
                await context.SaveChangesAsync();
            }
        }
    }


}
