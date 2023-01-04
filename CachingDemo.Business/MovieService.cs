using CachingDemo.Business.Entities;
using CachingDemo.Business.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CachingDemo.Business
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _dbContext;
        private readonly IMemoryCache memoryCache;

        public MovieService(DataContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            this.memoryCache = memoryCache;
        }

        public void Create(Movie movie)
        {
            _dbContext.Set<Movie>().Add(movie);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Movie? toDelete = Get(id);

            if (toDelete == null)
                return;

            _dbContext.Remove(toDelete);
            _dbContext.SaveChanges();
        }

        public Movie? Get(int id) => _dbContext.Set<Movie>().FirstOrDefault(x => x.Id == id);

        public IEnumerable<Movie> GetAll()
        {
            string key = "allmovies";

            Console.ForegroundColor = ConsoleColor.Red;

            if (!memoryCache.TryGetValue(key, out List<Movie>? movies))
            {
                Console.WriteLine("Key is not in cache.");
                movies = _dbContext.Set<Movie>().ToList();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

                memoryCache.Set(key, movies, cacheOptions);
            }
            else
            {
                Console.WriteLine("Already in cache.");
            }

            Console.ResetColor();

            return movies ?? new List<Movie>();
        }
    }
}
