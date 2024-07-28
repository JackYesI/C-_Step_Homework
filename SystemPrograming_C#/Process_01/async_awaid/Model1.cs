using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace async_awaid
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
    public partial class Model1 : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Library;Trusted_Connection=True;");
    }
}
}
