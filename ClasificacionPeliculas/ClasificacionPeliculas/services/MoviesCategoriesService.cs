using System.Text;
using ClasificacionPeliculasModel;
using Newtonsoft.Json;

public interface IMoviescategoriesService
{
  public Task<IEnumerable<Moviescategory>> GetMoviescategories();
  public Task<Moviescategory> GetMoviescategory(int id);
  public Task<Moviescategory> CreateMoviescategory(Moviescategory Moviescategory);
  public Task<Moviescategory> UpdateMoviescategory(Moviescategory Moviescategory);
  public Task<Moviescategory> DeleteMoviescategory(int id);

}

public class MoviescategoriesService : IMoviescategoriesService
{
  public async Task<Moviescategory> CreateMoviescategory(Moviescategory Moviescategory)
  {
    var client = new HttpClient();
    var json = JsonConvert.SerializeObject(new {
      MovieId = Moviescategory.MovieId,
      CategoryId = Moviescategory.CategoryId
    });
    var body = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PostAsync("http://localhost:5096/Moviescategories/create", body);
    var content = await response.Content.ReadAsStringAsync();
    Moviescategory _Moviescategory = JsonConvert.DeserializeObject<Moviescategory>(content);
    return _Moviescategory;
  }

  public async Task<Moviescategory> DeleteMoviescategory(int id)
  {
    var client = new HttpClient();
    var response = await client.DeleteAsync("http://localhost:5096/Moviescategories/delete/" + id);
    var content = await response.Content.ReadAsStringAsync();
    Moviescategory Moviescategory = JsonConvert.DeserializeObject<Moviescategory>(content);
    return Moviescategory;
  }

  public async Task<Moviescategory> GetMoviescategory(int id)
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/Moviescategories/" + id);
    var content = await response.Content.ReadAsStringAsync();
    Moviescategory Moviescategory = JsonConvert.DeserializeObject<Moviescategory>(content);
    return Moviescategory;
  }

  public async Task<IEnumerable<Moviescategory>> GetMoviescategories()
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/Moviescategories");
    var content = await response.Content.ReadAsStringAsync();
    IEnumerable<Moviescategory> Moviescategories = JsonConvert.DeserializeObject<IEnumerable<Moviescategory>>(content);
    return Moviescategories;
  }

  public async Task<Moviescategory> UpdateMoviescategory(Moviescategory Moviescategory)
  {
    var client = new HttpClient();
    var json = JsonConvert.SerializeObject(Moviescategory);
    var body = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PutAsync("http://localhost:5096/Moviescategories/update", body);
    var content = await response.Content.ReadAsStringAsync();
    Moviescategory Moviescategories = JsonConvert.DeserializeObject<Moviescategory>(content);
    return Moviescategories;
  }
}