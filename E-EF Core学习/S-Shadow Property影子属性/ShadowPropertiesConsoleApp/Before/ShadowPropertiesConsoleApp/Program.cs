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

Console.WriteLine($"user: {tweet.UserId} tweeted: \"{tweet.Text}\"");