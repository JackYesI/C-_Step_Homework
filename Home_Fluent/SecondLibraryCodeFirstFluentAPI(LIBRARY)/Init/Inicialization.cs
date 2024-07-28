using Microsoft.EntityFrameworkCore;
using SecondLibraryCodeFirstFluentAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLibraryCodeFirstFluentAPI.Init
{
    public static class Inicialization
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(new Categories[]
            {
                new Categories()
                {
                    Id = 1,
                    Name = "x",
                },
                new Categories()
                {
                    Id = 2,
                    Name = "y",
                },
                new Categories()
                {
                    Id = 3,
                    Name = "z",
                }
            });
        }
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>().HasData(new Countries[]
            {
                new Countries()
                {
                    Id = 1,
                    Name = "Ua",
                },
                new Countries()
                {
                    Id = 2,
                    Name = "Usa",
                },
                new Countries()
                {
                    Id = 3,
                    Name = "Pl",
                }
            });
        }
        public static void SeedPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Positions>().HasData(new Positions[]
            {
                new Positions()
                {
                    Id = 1,
                    Name = "The First",
                },
                new Positions()
                {
                    Id = 2,
                    Name = "The Second",
                },
                new Positions()
                {
                    Id = 3,
                    Name = "The Thirth",
                }
            });
        }
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>().HasData(new Cities[]
            {
                new Cities()
                {
                    Id = 1,
                    Name = "Rivne",
                    CountryId = 1
                },
                new Cities()
                {
                    Id = 2,
                    Name = "Texas",
                    CountryId = 2
                },
                new Cities()
                {
                    Id = 3,
                    Name = "Krakiv",
                    CountryId = 3
                }
            });
        }
        public static void SeedWorkers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workers>().HasData(new Workers[]
            {
                new Workers()
                {
                    Id = 1,
                    Name = "Petro",
                    Surname = "Shy",
                    Salary = 50,
                    Email = "nova@gmail",
                    PositionId = 1,
                    ShopId = 1,
                }
            });
        }
        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(new Products[]
            {
                new Products()
                {
                    Id = 1,
                    Name = "Banan",
                    Price = 50,
                    Discount = 2,
                    Quantity = 1,
                    IsitStock = true
                },
                new Products()
                {
                    Id = 1,
                    Name = "Buu",
                    Price = 5,
                    Discount = 3,
                    Quantity = 3,
                    IsitStock = false
                },
                new Products()
                {
                    Id = 1,
                    Name = "apple",
                    Price = 53,
                    Discount = 5,
                    Quantity = 5,
                    IsitStock = false
                },
                new Products()
                {
                    Id = 1,
                    Name = "orrange",
                    Price = 43,
                    Discount = 5,
                    Quantity = 11,
                    IsitStock = true
                }
            });
        }
        public static void SeedShops(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shops>().HasData(new Shops[]
            {
                new Shops()
                {
                    Id = 1,
                    Name = "Shop1",
                    Adress = "qdqdfwefewfew",
                    CityId = 1
                },
                new Shops()
                {
                    Id = 1,
                    Name = "Shop1",
                    Adress = "qdqdfwef234324ewfew",
                    CityId = 1
                },
                new Shops()
                {
                    Id = 1,
                    Name = "Shop1",
                    Adress = "qdqd45fwefewfew",
                    CityId = 3
                },
                new Shops()
                {
                    Id = 1,
                    Name = "Shop1",
                    Adress = "qdqdfw3463464efewfew",
                    CityId = 2
                }
            });
        }
    }
}
