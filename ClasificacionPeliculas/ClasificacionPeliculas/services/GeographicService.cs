using ClasificacionPeliculasModel;
using Newtonsoft.Json;

public interface IGeographicService
{
  public Task<IEnumerable<Region>> GetRegions();
  public Task<IEnumerable<City>> GetCitiesFromRegion(int regionID);
}

public class GeographicService : IGeographicService
{
  public async Task<IEnumerable<City>> GetCitiesFromRegion(int regionID)
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/geographic/GetCitiesFromRegion/" + regionID);
    var content = await response.Content.ReadAsStringAsync();
    IEnumerable<City> City = JsonConvert.DeserializeObject<IEnumerable<City>>(content);
    return City;
  }

  public async Task<IEnumerable<Region>> GetRegions()
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/geographic/GetRegions");
    var content = await response.Content.ReadAsStringAsync();
    IEnumerable<Region> Region = JsonConvert.DeserializeObject<IEnumerable<Region>>(content);
    return Region;
  }

}