using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc;
using api.Services;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviescategoriesController : ControllerBase
{
  private IDatabaseService<Moviescategory, int> db;
  public MoviescategoriesController(IDatabaseService<Moviescategory, int> _db)
  {
    this.db = _db;
  }


  [HttpGet("")]
  public ActionResult<List<Moviescategory>> getAll()
  {
    return db.GetAll();
  }

  [HttpPost("create")]
  public ActionResult<Moviescategory> CreateMoviescategory(Moviescategory body)
  {
    return db.Create(body);
  }

  [HttpGet("{id}")]
  public ActionResult<Moviescategory> GetMoviescategory(int id)
  {
    Moviescategory? updatedMoviescategory = db.GetOne(id);
    if (updatedMoviescategory == null) return NotFound();
    else return updatedMoviescategory;
  }

  [HttpPut("update")]
  public ActionResult<Moviescategory> UpdateMoviescategory(Moviescategory body)
  {
    Moviescategory? updatedMoviescategory = db.Update(body);
    if (updatedMoviescategory == null) return NotFound();
    else return updatedMoviescategory;
  }

  [HttpDelete("delete/{id}")]
  public ActionResult<Moviescategory> DeleteMoviescategory(int id)
  {
    Moviescategory? updatedMoviescategory = db.Delete(id);
    if (updatedMoviescategory == null) return NotFound();
    else return updatedMoviescategory;
  }
}
