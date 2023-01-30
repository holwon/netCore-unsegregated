using MyEFCore.Model;
using Microsoft.EntityFrameworkCore;

namespace MyEFCore;

partial class Program
{
    public class AppDbContext : DbContext
    {
        public DbSet<Fruit>? Fruits { get; set; }
        public DbSet<Address> Addresses { get; set; }
        // public DbSet<Fruit> Fruits => Set<Fruit>();
        public DbSet<Vegetable> Vegetables => Set<Vegetable>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./MyEFCore.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Fruit>().HasKey(f => f.Name);
            // modelBuilder.Entity<Vegetable>().HasKey(v => v.Name);
            // modelBuilder.Entity<Fruit>().Property(f => f.Name).HasMaxLength(20);
            modelBuilder.Entity<Fruit>().Property<int>("Id").HasColumnName("Id");
        }
        // public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        // {
        //     // Database.EnsureCreated();
        // }
    }

    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            var Apple = new Fruit { Name = "Apple", Weight = "1kg" };
            var EFBanana = new Fruit { Name = "Banana", Weight = "1kg" };
            context.Fruits.Add(Apple);
            context.Fruits.Add(EFBanana);

            var AppleId = context.Entry(Apple).Property<int>("Id").CurrentValue;

            context.SaveChanges();

            // var fruit = context.Fruits?.FirstOrDefault();

            var fruit1 = context.Fruits.Find(8);// Find是通过主键查找
            Console.WriteLine(fruit1?.Name + " " + fruit1.Id);


            var query = context.Fruits?.
            Select(f =>
            new FruitVM
            {
                Id = EF.Property<int>(f, "Id"),
                // Id = f.Id,
                Name = f.Name,
                Weight = f.Weight
            });
            string name = "Apple";
            if (name == "Apple")// condition
            {
                query = query.Where(f => f.Name == "Apple");
            }
            var fruits = query.ToList();


            // IEnumerable<Fruit> Banana = from f in context.Fruits
            var Banana = from f in context.Fruits
                         where f.Name == "Banana"
                         select f;
            foreach (var fruit in Banana)
            {
                System.Console.WriteLine($"Name: {fruit.Name}, Weight: {fruit.Weight}, Id: {fruit.Id}");
                // context.Remove(fruit);
            }
            // context.SaveChanges();
            // Console.WriteLine($"{fruit?.Name ?? "null"} {fruit?.Weight ?? "null"}");
            Console.WriteLine(context.Fruits?.Count());
            Console.WriteLine(context.Vegetables?.Count());
            // var apple = fruits.SingleOrDefault(f => f.Name == "Apple");
            // Console.WriteLine($"{apple?.Name ?? "null"} {apple?.Weight ?? "null"}");
            // context.Remove(fruit);
            // context?.SaveChanges();
            // Console.WriteLine(context.Fruits?.Count());
        }
        Console.ReadLine();
    }
}