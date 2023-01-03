using CachingDemo.Business.Entities;

namespace CachingDemo.Business.Interfaces
{
    internal interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Movie? Get(int id);
        void Delete(int id);
        void Create(Movie movie);
    }
}
