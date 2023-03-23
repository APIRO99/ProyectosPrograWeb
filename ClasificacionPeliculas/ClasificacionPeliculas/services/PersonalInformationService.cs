using System.Text;
using ClasificacionPeliculasModel;
using Newtonsoft.Json;

public interface IPersonalInformationsService
{
  public Task<IEnumerable<PersonalInformation>> GetPersonalInformations();
  public Task<PersonalInformation> GetPersonalInformation(int id);
  public Task<PersonalInformation> CreatePersonalInformation(PersonalInformation PersonalInformation);
  public Task<PersonalInformation> UpdatePersonalInformation(PersonalInformation PersonalInformation);
  public Task<PersonalInformation> DeletePersonalInformation(int id);

}

public class PersonalInformationsService : IPersonalInformationsService
{
  public async Task<PersonalInformation> CreatePersonalInformation(PersonalInformation PersonalInformation)
  {
    var client = new HttpClient();
    var json = JsonConvert.SerializeObject(new {
      GeonameidCity = PersonalInformation.GeonameidCity,
      Name = PersonalInformation.Name,
      DateOfBirth = PersonalInformation.DateOfBirth,
      Email = PersonalInformation.Email,
      PhoneNumber = PersonalInformation.PhoneNumber,
      Address = PersonalInformation.Address,
    });
    var body = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PostAsync("http://localhost:5096/PersonalInformation/create", body);
    var content = await response.Content.ReadAsStringAsync();
    PersonalInformation _PersonalInformation = JsonConvert.DeserializeObject<PersonalInformation>(content);
    return _PersonalInformation;
  }

  public async Task<PersonalInformation> DeletePersonalInformation(int id)
  {
    var client = new HttpClient();
    var response = await client.DeleteAsync("http://localhost:5096/PersonalInformation/delete/" + id);
    var content = await response.Content.ReadAsStringAsync();
    PersonalInformation PersonalInformation = JsonConvert.DeserializeObject<PersonalInformation>(content);
    return PersonalInformation;
  }

  public async Task<PersonalInformation> GetPersonalInformation(int id)
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/PersonalInformation/" + id);
    var content = await response.Content.ReadAsStringAsync();
    PersonalInformation PersonalInformation = JsonConvert.DeserializeObject<PersonalInformation>(content);
    return PersonalInformation;
  }

  public async Task<IEnumerable<PersonalInformation>> GetPersonalInformations()
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/PersonalInformation");
    var content = await response.Content.ReadAsStringAsync();
    IEnumerable<PersonalInformation> PersonalInformations = JsonConvert.DeserializeObject<IEnumerable<PersonalInformation>>(content);
    return PersonalInformations;
  }

  public async Task<PersonalInformation> UpdatePersonalInformation(PersonalInformation PersonalInformation)
  {
    var client = new HttpClient();
    var json = JsonConvert.SerializeObject(PersonalInformation);
    var body = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PutAsync("http://localhost:5096/PersonalInformation/update", body);
    var content = await response.Content.ReadAsStringAsync();
    PersonalInformation PersonalInformations = JsonConvert.DeserializeObject<PersonalInformation>(content);
    return PersonalInformations;
  }
}