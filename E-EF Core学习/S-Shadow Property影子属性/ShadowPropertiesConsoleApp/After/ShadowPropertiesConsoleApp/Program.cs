using Microsoft.EntityFrameworkCore;
using ShadowPropertiesConsoleApp;

Console.WriteLine("Hello, World!");

using var db = new Db();

await db.Database.EnsureDeletedAsync();
await db.Database.EnsureCreatedAsync();


User user = new()
{
    Name = "Full Stack Amigo",
    Tweets = new Tweet[]
    {
        new() { Text = "Shadow Properties are awesome!" }
    }
};

db.Users.Add(user);

await db.SaveChangesAsync();

var tweet = await db.Tweets.FirstAsync();

var userId = db.Entry(tweet).Property<int>("UserId1").CurrentValue;
//db.Entry(tweet).Property<int?>("UserId").CurrentValue = 3;
Console.WriteLine($"user: {userId} tweeted: \"{tweet.Text}\"");

var tweets = db.Tweets.Where(x => EF.Property<int>(x, "UserId1") == 1).ToArray();
Console.WriteLine(tweets[0].Text);


