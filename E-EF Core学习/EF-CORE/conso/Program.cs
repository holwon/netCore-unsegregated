namespace conso;
using conso.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class StudentContext : DbContext
{
    public DbSet<Student>? Students { get; set; }
    public DbSet<College>? Colleges { get; set; }
    public DbSet<Course>? Courses { get; set; }
    // public DbSet<Student> Students => Set<Student>();
    // public DbSet<Course> Courses => Set<Course>();
    // public DbSet<College> Colleges => Set<College>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=StudentDB;Trusted_Connection=True;");
        optionsBuilder.UseSqlServer(@"Data Source=127.0.0.1;Initial Catalog=StudentDB;User ID=sa;Password=123456;");
        // }Data Source = 127.0.0.1; Initial Catalog = Student; Integrated Security = True
    }
}
class Program
{
    static void Main(string[] args)
    {
        using (var context = new StudentContext())
        {
            var student1 = new Student { Name = "zz" };
            context.Students!.Add(student1);
            //context.Database.Migrate();
            context.SaveChanges();
            var student = context.Students.FirstOrDefault();
            System.Console.WriteLine(student?.Name);
        }
        Console.ReadLine();
    }
}

