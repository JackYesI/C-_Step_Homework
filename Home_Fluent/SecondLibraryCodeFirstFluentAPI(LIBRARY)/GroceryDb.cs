using Microsoft.EntityFrameworkCore;
using SecondLibraryCodeFirstFluentAPI.Classes;
using SecondLibraryCodeFirstFluentAPI.Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLibraryCodeFirstFluentAPI
{
    public class GroceryDb : DbContext
    {
        public GroceryDb()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;
                                    initial catalog=newGrocery;
                                    integrated security=True;
                                    Connect Timeout = 2;
                                    Encrypt = False;
                                    Trust Server Certificate = False;
                                    Application Intent = ReadWrite;
                                    Multi Subnet Failover = False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categories>()
                .Property(a => a.Name) 
                .IsRequired() 
                .HasMaxLength(100);


            modelBuilder.Entity<Positions>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Countries>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Cities>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Cities>()
                .Property(a => a.CountryId)
                .IsRequired();

            modelBuilder.Entity<Products>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Products>()
                .Property(a => a.Price)
                .IsRequired()
                .HasSentinel(5);
            modelBuilder.Entity<Products>()
                .Property(a => a.Discount)
                .IsRequired();
            modelBuilder.Entity<Products>()
                .Property(a => a.IsitStock)
                .IsRequired();
            modelBuilder.Entity<Products>()
                .Property(a => a.Quantity)
                .IsRequired();

            modelBuilder.Entity<Shops>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Shops>()
                .Property(a => a.Adress)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Shops>()
                .Property(a => a.CityId)
                .IsRequired();

            modelBuilder.Entity<Workers>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Workers>()
                .Property(a => a.Surname)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Workers>()
                .Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Workers>()
                .Property(a => a.Phone)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValue("0965878222");
            modelBuilder.Entity<Workers>()
                .Property(a => a.PositionId)
                .IsRequired();
            modelBuilder.Entity<Workers>()
                .Property(a => a.ShopId)
                .IsRequired();



            // one to many (1 .... *)
            modelBuilder.Entity<Cities>()
                .HasOne(f => f.Countries)
                .WithMany(f => f.City)
                .HasForeignKey(f => f.CountryId);

            modelBuilder.Entity<Products>()
                .HasOne(f => f.Categories)
                .WithMany(f => f.Products)
                .HasForeignKey(f => f.CategoryId);

            modelBuilder.Entity<Shops>()
                .HasOne(f => f.Cities)
                .WithMany(f => f.Shops)
                .HasForeignKey(f => f.CityId);

            modelBuilder.Entity<Workers>()
                .HasOne(f => f.Shops)
                .WithMany(f => f.Workers)
                .HasForeignKey(f => f.ShopId);

            modelBuilder.Entity<Workers>()
                .HasOne(f => f.Positions)
                .WithMany(f => f.Workers)
                .HasForeignKey(f => f.PositionId);

            //many to many(*......*)
            modelBuilder.Entity<Shops>()
                .HasMany(f => f.Products)
                .WithMany(f => f.Shops);

            modelBuilder.SeedCategories();
            modelBuilder.SeedCities();
            modelBuilder.SeedCountries();
            modelBuilder.SeedPositions();
            modelBuilder.SeedProduct();
            modelBuilder.SeedWorkers();
            modelBuilder.SeedShops();

        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Shops> Shops { get; set; }
        public DbSet<Workers> Workers { get; set;}
        public DbSet<Positions> Positions { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }

    }
}
