using Movies.Client.Models;

namespace Movies.Client.HttpServices;

public interface IMovieHttpService 
{
    Task<IEnumerable<Movie>> GetMovies();
    Task<Movie> GetMovie(int id);
    Task<Movie> CreateMovie(Movie movie);
    Task<Movie> UpdateMovie(Movie movie);
    Task DeleteMovie(int id);   
}


public class MovieHttpService : IMovieHttpService
{
    public async Task<Movie> CreateMovie(Movie movie)
    {
        return new();
    }

    public async Task DeleteMovie(int id)
    {

    }

    public async Task<Movie> GetMovie(int id)
    {
        return new();
    }

    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return new List<Movie>();
    }

    public async Task<Movie> UpdateMovie(Movie movie)
    {
        return new();
    }
}
