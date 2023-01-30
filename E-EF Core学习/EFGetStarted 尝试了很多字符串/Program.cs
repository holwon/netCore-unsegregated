using var db = new BloggingContext();

db.Database.EnsureDeleted();
db.Database.EnsureCreated();


// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");
System.Console.WriteLine(db.ChangeTracker.HasChanges());

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
Console.WriteLine(db.ChangeTracker.DebugView.ShortView);

System.Console.WriteLine(db.ChangeTracker.HasChanges());
Console.WriteLine(db.ChangeTracker.DebugView.LongView);
db.SaveChanges();
System.Console.WriteLine("save changes over");
System.Console.WriteLine(db.ChangeTracker.HasChanges());

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

Console.WriteLine(db.ChangeTracker.DebugView.ShortView);

Console.WriteLine(blog.BlogId + " is " + blog.Url);
// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });

Console.WriteLine(db.ChangeTracker.DebugView.LongView);
db.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);

Console.WriteLine(db.ChangeTracker.DebugView.LongView);
// db.SaveChanges();