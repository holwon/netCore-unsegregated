using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Tag> Tags => Set<Tag>();

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // options.UseSqlite($"Data Source=./data.db");
        options.UseSqlServer(
            @"Data Source=(localdb)\.;
        Integrated Security=True;
Initial Catalog=Course2;
AttachDBFilename=E:\a2230\Documents\projects\.NET Core\E-EF Core学习\多对多2\App_Data\Course2.mdf;Timeout=15");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
        .HasMany(A => A.Tags)
        .WithMany(t => t.Articles)
        .UsingEntity(at => at.ToTable("ArticleTag"));
    }

}
