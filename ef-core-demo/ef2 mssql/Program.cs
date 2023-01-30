using Microsoft.EntityFrameworkCore;
// using System.Data.Entity.Infrastructure;

namespace CSharp;

public partial class Program
{

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=ef2;Trusted_Connection=True;ConnectRetryCount=0");
        }
    }
    static void Main(string[] args)
    {
        System.Console.WriteLine("Hello World!");
    }
}
