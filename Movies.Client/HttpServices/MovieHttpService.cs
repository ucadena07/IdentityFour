using IdentityModel.Client;
using Movies.Client.Models;
using System.Text.Json;

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
    private readonly IHttpClientFactory _httpClientFactory;

    public MovieHttpService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
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

        var httpClient = _httpClientFactory.CreateClient("MovieApiClient");

        var request = new HttpRequestMessage(
                HttpMethod.Get,
                "/api/movies/"
            );
        var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var opt = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        List<Movie> movieList = System.Text.Json.JsonSerializer.Deserialize<List<Movie>>(content, opt) ?? new();

        //get token from identity server
        //var apiClientCredentials = new ClientCredentialsTokenRequest
        //{
        //    Address = "https://localhost:7042/connect/token",
        //    ClientId = "movieClient",
        //    ClientSecret = "secret",

        //    // This is the scope our protected API requires.
        //    Scope = "movieAPI"
        //};

        //check if identity server is running
        //var client = new HttpClient();

        //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:7042");
        //if (disco.IsError)
        //{
        //    return null;
        //}

        //Authenticates and get an access token form IS
        //var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);  
        //if(tokenResponse.IsError)
        //{
        //    return null;
        //}

        //send request to protected api
        var apiClient = new HttpClient();
        //apiClient.SetBearerToken(tokenResponse.AccessToken);

        //var response = await apiClient.GetAsync("https://localhost:7072/api/movies");
        //response.EnsureSuccessStatusCode(); 



        //Deserialize object


        return movieList;
    }

    public async Task<Movie> UpdateMovie(Movie movie)
    {
        return new();
    }
}
