using Microsoft.EntityFrameworkCore;

namespace ShadowPropertiesConsoleApp
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Tweet> Tweets { get; set; }
    }

    public class Tweet
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class Db : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=.;User Id=sa; Password=SecretP@ss; Database=MyTestDatabase");
            optionsBuilder.UseSqlServer(
            // "Server=.;User Id=sa; Password=SecretP@ss; Database=MyTestDatabase");
            @"Data Source=(localdb)\.;Integrated Security=True;
            Initial Catalog=test;
            AttachDBFilename=E:\a2230\Documents\projects\.NET Core\E-EF Core学习\S-Shadow Property影子属性\ShadowPropertiesConsoleApp\After\ShadowPropertiesConsoleApp\test.mdf;
            Timeout=15");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tweet>()
                .HasOne<User>()
                .WithMany(x => x.Tweets)
                .HasForeignKey("UserId1")
                .IsRequired();

            modelBuilder.Entity<Tweet>()
                .Property<DateTime>("LastModified");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
    }
}
