using CachingDemo.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace CachingDemo.Business
{
    public class DataContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Rating = 5,
                    ReleaseDate = new DateTime(2001, 7, 12),
                    Title = "Shrek"
                },
                new Movie
                {
                    Id = 2,
                    Rating = 3,
                    ReleaseDate = new DateTime(2010, 7, 22),
                    Title = "Inception"
                },
                new Movie
                {
                    Id = 3,
                    Rating = 4,
                    ReleaseDate = new DateTime(1999, 6, 17),
                    Title = "The Matrix"
                },
                new Movie
                {
                    Id = 4,
                    Rating = 5,
                    ReleaseDate = new DateTime(1968, 6, 30),
                    Title = "Top Gun"
                },
                new Movie
                {
                    Id = 5,
                    Rating = 5,
                    ReleaseDate = new DateTime(2011, 12, 8),
                    Title = "Puss in Boots"
                },
                new Movie
                {
                    Id = 6,
                    Rating = 5,
                    ReleaseDate = new DateTime(2022, 12, 26),
                    Title = "Puss in Boots: The Last Wish"
                }
            );
        }
    }
}
