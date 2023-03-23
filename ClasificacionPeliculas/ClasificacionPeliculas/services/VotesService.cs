using System.Text;
using ClasificacionPeliculasModel;
using Newtonsoft.Json;

public interface IVotesService
{
  public Task<IEnumerable<Vote>> GetVotos();
  public Task<Vote> GetVoto(int id);
  public Task<Vote> CreateVoto(Vote vote);
  public Task<Vote> UpdateVoto(Vote vote);
  public Task<Vote> DeleteVoto(int id);

}

public class VotesService : IVotesService
{
  public async Task<Vote> CreateVoto(Vote vote)
  {
    var client = new HttpClient();
    var json = JsonConvert.SerializeObject(new {
      piId = vote.PiId,
      moviesId = vote.MoviesId,
      rate = vote.Rate
    });
    var body = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PostAsync("http://localhost:5096/vote/create", body);
    var content = await response.Content.ReadAsStringAsync();
    Vote _vote = JsonConvert.DeserializeObject<Vote>(content);
    return _vote;
  }

  public async Task<Vote> DeleteVoto(int id)
  {
    var client = new HttpClient();
    var response = await client.DeleteAsync("http://localhost:5096/vote/delete/" + id);
    var content = await response.Content.ReadAsStringAsync();
    Vote vote = JsonConvert.DeserializeObject<Vote>(content);
    return vote;
  }

  public async Task<Vote> GetVoto(int id)
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/vote/" + id);
    var content = await response.Content.ReadAsStringAsync();
    Vote vote = JsonConvert.DeserializeObject<Vote>(content);
    return vote;
  }

  public async Task<IEnumerable<Vote>> GetVotos()
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/vote");
    var content = await response.Content.ReadAsStringAsync();
    IEnumerable<Vote> votes = JsonConvert.DeserializeObject<IEnumerable<Vote>>(content);
    return votes;
  }

  public async Task<Vote> UpdateVoto(Vote vote)
  {
    var client = new HttpClient();
    var json = JsonConvert.SerializeObject(vote);
    var body = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PutAsync("http://localhost:5096/vote/update", body);
    var content = await response.Content.ReadAsStringAsync();
    Vote votes = JsonConvert.DeserializeObject<Vote>(content);
    return votes;
  }
}