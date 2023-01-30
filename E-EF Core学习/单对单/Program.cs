// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

DataContext context = new DataContext();
AppUser appUser = new() { Name = "appuser1" };
User user = new User() { Name = "user1" };
appUser.User = user;
// context.AppUser.Add(appUser);
// context.SaveChanges();
var user1 = context.User.Include(u => u.AppUser).First();

System.Console.WriteLine("Hello world!");
