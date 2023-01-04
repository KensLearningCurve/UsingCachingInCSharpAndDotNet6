using CachingDemo.Business;
using CachingDemo.Business.Entities;
using CachingDemo.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new();
services.AddMemoryCache();
services.AddScoped<IMovieService, MovieService>();
services.AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CacheDemo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

ServiceProvider serviceProvider = services.BuildServiceProvider();

IMovieService movieService = serviceProvider.GetRequiredService<IMovieService>();

Console.WriteLine("First run:");
List<Movie> allMovies = movieService.GetAll().ToList();

foreach (Movie movie in allMovies)
{
    Console.WriteLine(movie.Title);
}

Console.WriteLine();
Console.WriteLine("Press key");
Console.ReadLine();

Console.WriteLine("Second run:");
List<Movie> sortedMovies = movieService.GetAll().OrderBy(x => x.Title).ToList();

foreach (Movie movie in sortedMovies)
{
    Console.WriteLine(movie.Title);
}