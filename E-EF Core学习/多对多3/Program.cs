using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                // We create a clean DB per run
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Create movies and genres
                var drama = new Genre() { Name = "Drama" };
                var action = new Genre() { Name = "Action" };
                var animation = new Genre() { Name = "Animation" };

                var avengers = new Movie() { Title = "Avengers", Genres = new() { action } };
                var spiderman = new Movie() { Title = "Spiderman: Spiderverse", Genres = new() { action, animation } };
                var inception = new Movie() { Title = "Inception", Genres = new() { drama } };

                context.AddRange(drama, action, animation, avengers, spiderman, inception);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext())
            {
                Console.Clear();
                //var moviesWithGenres = context.Movies.Include(x => x.Genres).ToList();
                //PrintMovies(moviesWithGenres);

                //var actionMovies = context.Movies.Include(x => x.Genres)
                //    .Where(movie => movie.Genres.Select(genre => genre.Name).Contains("Action"))
                //    .ToList();
                //PrintMovies(actionMovies);

                //var moviesAndGenresThatStartWithA = context.Movies
                //    .Include(movie => movie.Genres.Where(genre => genre.Name.StartsWith("A")))
                //    .ToList();
                //PrintMovies(moviesAndGenresThatStartWithA);

                var moviesWithGenresThatDoesntStartWithA = context.Movies.Include(x => x.Genres)
                    .Where(movie =>
                    movie.Genres.Where(genre => !genre.Name.StartsWith("A")).Count() > 0)
                    .ToList();
                PrintMovies(moviesWithGenresThatDoesntStartWithA);
            }
        }

        private static void PrintMovies(List<Movie> movies)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var movie in movies)
            {
                Console.WriteLine($"Title: {movie.Title}");
                if (movie.Genres != null)
                {
                    foreach (var genre in movie.Genres)
                    {
                        Console.WriteLine($"  - {genre.Name}");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class Genre
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        [StringLength(120)]
        public string Title { get; set; }
        public List<Genre> Genres { get; set; }
    }

    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EFCore5_manytomany;Integrated Security=True")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}