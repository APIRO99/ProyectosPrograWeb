using System.Text;
using ClasificacionPeliculasModel;
using Newtonsoft.Json;

public interface ICategoriesService
{
  public Task<IEnumerable<Category>> GetCategories();
  public Task<Category> GetCategory(int id);
  public Task<Category> CreateCategory(Category Category);
  public Task<Category> UpdateCategory(Category Category);
  public Task<Category> DeleteCategory(int id);

}

public class CategoriesService : ICategoriesService
{
  public async Task<Category> CreateCategory(Category Category)
  {
    var client = new HttpClient();
    var json = JsonConvert.SerializeObject(new {
      name = Category.Name
    });
    var body = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PostAsync("http://localhost:5096/Categories/create", body);
    var content = await response.Content.ReadAsStringAsync();
    Category _Category = JsonConvert.DeserializeObject<Category>(content);
    return _Category;
  }

  public async Task<Category> DeleteCategory(int id)
  {
    var client = new HttpClient();
    var response = await client.DeleteAsync("http://localhost:5096/Categories/delete/" + id);
    var content = await response.Content.ReadAsStringAsync();
    Category Category = JsonConvert.DeserializeObject<Category>(content);
    return Category;
  }

  public async Task<Category> GetCategory(int id)
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/Categories/" + id);
    var content = await response.Content.ReadAsStringAsync();
    Category Category = JsonConvert.DeserializeObject<Category>(content);
    return Category;
  }

  public async Task<IEnumerable<Category>> GetCategories()
  {
    var client = new HttpClient();
    var response = await client.GetAsync("http://localhost:5096/Categories");
    var content = await response.Content.ReadAsStringAsync();
    IEnumerable<Category> Categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(content);
    return Categories;
  }

  public async Task<Category> UpdateCategory(Category Category)
  {
    var client = new HttpClient();
    var json = JsonConvert.SerializeObject(Category);
    var body = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await client.PutAsync("http://localhost:5096/Categories/update", body);
    var content = await response.Content.ReadAsStringAsync();
    Category Categories = JsonConvert.DeserializeObject<Category>(content);
    return Categories;
  }
}