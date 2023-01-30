using Microsoft.EntityFrameworkCore;
using P.Models;

public class DataContext : DbContext
{
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<CourseTeacher> CourseTeachers => Set<CourseTeacher>();

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        =>
    // options.UseSqlite($"Data Source=./data.db");
    options.UseSqlServer(
        @"Data Source=(localdb)\.;
        Integrated Security=True;
Initial Catalog=Course;
AttachDBFilename=E:\a2230\Documents\projects\.NET Core\E-EF Core学习\多对多\App_Data\Course.mdf;Timeout=15");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseTeacher>()
        .HasKey(ct => new { ct.CourseId, ct.TeacherId });

        modelBuilder.Entity<CourseTeacher>()
        .HasOne(ct => ct.Course)
        .WithMany(ct => ct.Teachers)
        .HasForeignKey(ct => ct.CourseId);

        modelBuilder.Entity<CourseTeacher>()
        .HasOne(ct => ct.Teacher)
        .WithMany(ct => ct.Courses)
        .HasForeignKey(ct => ct.TeacherId);
    }

}
