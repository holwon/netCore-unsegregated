using Microsoft.EntityFrameworkCore;

DataContext data = new();

// var many = data.Articles.Include("Tags").ToList();
// var many = data.Articles.Include(x => x.Tags).Where(t => t.Tags.Count > 0).ToList();
// foreach (var item in many)
// {
//     System.Console.WriteLine(item.Id);
// }

Article a1 = new() { Title = "a1", Content = "a1" };
Article a2 = new() { Title = "a2", Content = "a2" };

Tag t1 = new() { Name = "t1", Articles = new List<Article>() { a1 }, Description = "description" };
Tag t2 = new() { Name = "t2", Articles = new List<Article>() { a2 }, Description = "description" };
Tag t3 = new() { Name = "t3", Articles = new List<Article>() { a2 }, Description = "description" };

Tag t4 = new() { Name = "t4", Description = "description" };

Article a3 = new() { Title = "a3", Tags = new List<Tag>() { t4 }, Content = "a3" };

var real_t4 = data.Tags.Where(t => t.Name == "t4").FirstOrDefault();

Article a4 = new() { Title = "a4", Tags = new List<Tag>() { real_t4 }, Content = "a4" };

Tag static_t4 = new() { Id = 8, Name = "t4", Description = "description" };

// a5这种不行
Article a5 = new() { Title = "a5", Tags = new List<Tag>() { static_t4 }, Content = "a5" };
// data.Articles.Add(a1);
Tag t5 = new() { Name = "t5", Articles = new List<Article>() { a2 }, Description = "description" };
// data.Tags.Add(t5);

var tmpA = data.Articles.Include(a => a.Tags).Where(a => a.Id == 1).First();
// tmpA.Tags.Add(static_t4);// 这样是无法被追踪的

// data.Articles.Add(a4);
// var tag = data.Tags.Where(x => x.Id == 2).Include(x => x.Articles).FirstOrDefault();
// var tag2 = data.Tags.Include(x => x.Articles).FirstOrDefault(x => x.Id == 2);
// var article = data.Articles.Where(x => x.Id == 2).Include(x => x.Tags).First();
// var article2 = data.Articles.Where(x => x.Title == "asd").Include(x => x.Tags).First();
// article.Tags.Add(tag);
// var articles = data.Articles.Include(x => x.Tags).ToList();

data.SaveChanges();