using CachingDemo.Business;
using CachingDemo.Business.Entities;

MovieService movieService = new();

List<Movie> allMovies = movieService.GetAll().ToList();

foreach (Movie movie in allMovies)
{
    Console.WriteLine(movie.Title);
}