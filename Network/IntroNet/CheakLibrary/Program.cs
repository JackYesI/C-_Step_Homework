
using Microsoft.EntityFrameworkCore;


internal class Program
{
    public class PostalCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public ICollection<Street> Streets { get; set; }
    }
    public class Street
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostalCodeId { get; set; }
        public PostalCode PostalCode { get; set; }
    }
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
    private static void Main(string[] args)
    {
        var connectionString = @"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Post_DB;integrated security=True;Connect Timeout=2;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Створюємо об'єкт параметрів підключення
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        // Створюємо об'єкт контексту бази даних
        using (var dbContext = new AppDbContext(optionsBuilder.Options))
        {
            // Переконайтеся, що база даних створена або мігруйте її, якщо потрібно
            dbContext.Database.EnsureCreated();

            // Виберіть всі поштові індекси з бази даних разом з відповідними вулицями
            var postalCodesWithStreets = dbContext.PostalCodes.Include(p => p.Streets).ToList();

            // Тепер ви можете пройтися по цьому списку і витягти дані
            foreach (var postalCode in postalCodesWithStreets)
            {
                Console.WriteLine($"Поштовий індекс: {postalCode.Code}");
                foreach (var street in postalCode.Streets)
                {
                    Console.WriteLine($"   Вулиця: {street.Name}");
                }
            }
        }
    }
}