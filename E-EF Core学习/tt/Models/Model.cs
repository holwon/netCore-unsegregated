using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
        // var folder = Environment.SpecialFolder.LocalApplicationData;
        // var path = Environment.GetFolderPath(folder);
        // DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        =>
    // options.UseSqlite($"Data Source={DbPath}");
    options.UseSqlite($"Data Source=./blogging.db");
    // options.UseSqlServer(
    // @"Data Source=(localdb)\.;Integrated Security=SSPI;User Instance=True;AttachDBFilename=|DataDirectory|\c.mdf");
    // @"Data Source=(localdb)\.;Integrated Security=TRUE;Database=ccc;AttachDBFilename=ccc.mdf;Timeout=120");
    // 最后使用绝对路径成功了, 不知为何无法使用相对路径
    // @"Data Source=(localdb)\.;Integrated Security=True;Initial Catalog=ccc;AttachDBFilename=E:\a2230\Documents\projects\.NET Core\E-EF Core\EFGetStarted\App_Data\ccc.mdf;Timeout=15");
    // @"Data Source=(localdb)\.;Integrated Security=True;AttachDBFilename=|DataDirectory|App_Data\ccc.mdf;Timeout=15");
}
