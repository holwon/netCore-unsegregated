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

        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class Db : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;User Id=sa; Password=SecretP@ss; Database=MyTestDatabase");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
    }
}
