using CachingDemo.Business;
using CachingDemo.Business.Entities;

MovieService movieService = new();

List<Movie> allMovies = movieService.GetAll().ToList();

foreach (Movie movie in allMovies)
{
    Console.WriteLine(movie.Title);
}

List<Movie> sortedMovies = movieService.GetAll().OrderBy(x => x.Title).ToList();

foreach (Movie movie in sortedMovies)
{
    Console.WriteLine(movie.Title);
}