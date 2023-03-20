using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc;
using api.Services;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
  private IDatabaseService<Category, int> db;
  public CategoriesController(IDatabaseService<Category, int> _db)
  {
    this.db = _db;
  }


  [HttpGet("")]
  public ActionResult<List<Category>> getAll()
  {
    return db.GetAll();
  }

  [HttpPost("create")]
  public ActionResult<Category> CreateCategory(Category body)
  {
    return db.Create(body);
  }

  [HttpGet("{id}")]
  public ActionResult<Category> GetCategory(int id)
  {
    Category? updatedCategory = db.Delete(id);
    if (updatedCategory == null) return NotFound();
    else return updatedCategory;
  }

  [HttpPut("update")]
  public ActionResult<Category> UpdateCategory(Category body)
  {
    Category? updatedCategory = db.Update(body);
    if (updatedCategory == null) return NotFound();
    else return updatedCategory;
  }

  [HttpDelete("delete/{id}")]
  public ActionResult<Category> DeleteCategory(int id)
  {
    Category? updatedCategory = db.Delete(id);
    if (updatedCategory == null) return NotFound();
    else return updatedCategory;
  }
}
