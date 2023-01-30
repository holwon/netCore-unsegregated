using Microsoft.EntityFrameworkCore;
// using System.Data.Entity.Infrastructure;

namespace CSharp;

public partial class Program
{

    public partial class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./blogging.db");
        }
    }
    static void Main(string[] args)
    {
        using (var ctx = new BloggingContext())
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.Migrate();
            Blog blog = new Blog { Url = "http://blogs.msdn.com/adonet" };
            ctx.Blogs.Add(blog);
            ctx.SaveChanges();
            int blogId = ctx.Blogs.Find(blog.BlogId).BlogId;
            Post post1 = new Post { Title = "Hello World", Content = "Hello World!", BlogId = blogId };
            ctx.Posts.Add(post1);

            Post post2 = new Post { Title = "Hello World 2", Content = "Hello World 2!", BlogId = 2 };
            // 因为有外键约束，所以不能添加post2
            // // ctx.Posts.Add(post2);// 报错：无法添加，因为外键约束
            ctx.SaveChanges();
        }
    }
}
