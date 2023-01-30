using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<AppUser> AppUser => Set<AppUser>();
    public DbSet<User> User => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        =>
    options.UseSqlite("Data Source=./single.db");
}
