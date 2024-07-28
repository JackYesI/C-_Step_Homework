using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


// connection string is 
//@"data source=(LocalDb)\MSSQLLocalDB;
//initial catalog = Post_DB;
//integrated security = True;
//Connect Timeout = 2;
//Encrypt = False;
//Trust Server Certificate = False;
//Application Intent = ReadWrite;
//Multi Subnet Failover = False"

namespace Post_Index_DB
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{
        //}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Street>()
                .HasOne(s => s.PostalCode)
                .WithMany(p => p.Streets)
                .HasForeignKey(s => s.PostalCodeId);

            // Додавання початкових даних
            modelBuilder.Entity<PostalCode>().HasData(
                new PostalCode { Id = 1, Code = "12345" },
                new PostalCode { Id = 2, Code = "54321" }
            );

            modelBuilder.Entity<Street>().HasData(
                new Street { Id = 1, Name = "First Street", PostalCodeId = 1 },
                new Street { Id = 2, Name = "Second Street", PostalCodeId = 1 },
                new Street { Id = 3, Name = "Third Street", PostalCodeId = 2 }
            );
        }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<Street> Streets { get; set; }
    }

}
