using System.Text;
using ClasificacionPeliculasModel;
using Newtonsoft.Json;

public interface IMoviesService
{
  public Task<IEnumerable<Movie>> GetMovies();
  public Task<Movie> GetMovie(int id);
  public Task<Movie> CreateMovie(Movie Movie);
  public Task<Movie> UpdateMovie(Movie Movie);
  public Task<Movie> DeleteMovie(int id);

}

public class MoviesService : IMoviesService
{
  public async Task<Movie> CreateMovie(Movie Movie)
  {
    var client = new HttpClient();
    var json = JsonConvert.SerializeObject(new {
      Title = Movie.Title,
      ReleaseDate = Movie.ReleaseDate,
      Duration = Movie.Duration,
      Director = Movie.Director,
      Actors = Movie.Actors,
      Plot = Movie.Plot,
      Rating = Movie.Rating,
      Votes = Movie.Votes,
      PosterUrl = Movie.PosterUrl,
      ImdbId = Movie.ImdbId
    });
    var body = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PostAsync("http://localhost:5096/Movies/create", body);
    var content = await response.Content.ReadAsStringAsync();
    Movie _Movie = JsonConvert.DeserializeObject<Movie>(content);
    return _Movie;
  }

  public async Task<Movie> DeleteMovie(int id)
  {
    var client = new HttpClient();
    var response = await client.DeleteAsync("http://localhost:5096/Movies/delete/" + id);
    var content = await response.Content.ReadAsStringAsync();
    Movie Movie = JsonConvert.DeserializeObject<Movie>(content);
    return Movie;
  }

  public async Task<Movie> GetMovie(int id)
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/Movies/" + id);
    var content = await response.Content.ReadAsStringAsync();
    Movie Movie = JsonConvert.DeserializeObject<Movie>(content);
    return Movie;
  }

  public async Task<IEnumerable<Movie>> GetMovies()
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/Movies");
    var content = await response.Content.ReadAsStringAsync();
    IEnumerable<Movie> Movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(content);
    return Movies;
  }

  public async Task<Movie> UpdateMovie(Movie Movie)
  {
    var client = new HttpClient();
    var json = JsonConvert.SerializeObject(Movie);
    var body = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PutAsync("http://localhost:5096/Movies/update", body);
    var content = await response.Content.ReadAsStringAsync();
    Movie Movies = JsonConvert.DeserializeObject<Movie>(content);
    return Movies;
  }
}