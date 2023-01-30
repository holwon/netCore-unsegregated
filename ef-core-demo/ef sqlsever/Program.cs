using Microsoft.EntityFrameworkCore;

// using ef2_mssql.Context;
using ef2_mssql.Model;

namespace ef2_mssql;


class Program
{
    public class BloggingContext : DbContext
    {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=ef2_mssql;Trusted_Connection=True;");
        }
    }
    public static void Main(string[] args)
    {
        // using (var db = new BloggingContext())
        // {
        //     db.Database.EnsureCreated();
        //     db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
        //     var count = db.SaveChanges();
        //     Console.WriteLine("{0} records saved to database", count);

        //     Console.WriteLine();
        //     Console.WriteLine("All blogs in database:");
        //     foreach (var blog in db.Blogs)
        //     {
        //         Console.WriteLine(" - {0}", blog.Url);
        //     }
        // }
        System.Console.WriteLine("Hello World!");
    }
}