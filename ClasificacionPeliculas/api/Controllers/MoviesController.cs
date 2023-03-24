using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc;
using api.Services;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
  private IMoviesService db;
  public MoviesController(IMoviesService _db)
  {
    this.db = _db;
  }


  [HttpGet("")]
  public ActionResult<List<Movie>> getAll()
  {
    return db.GetAll();
  }

  [HttpPost("create")]
  public ActionResult<Movie> CreateMovie(Movie body)
  {
    return db.Create(body);
  }

  [HttpGet("{id}")]
  public ActionResult<Movie> GetMovie(int id)
  {
    Movie? updatedMovie = db.GetOne(id);
    if (updatedMovie == null) return NotFound();
    else return updatedMovie;
  }

  [HttpPut("update")]
  public ActionResult<Movie> UpdateMovie(Movie body)
  {
    Movie? updatedMovie = db.Update(body);
    if (updatedMovie == null) return NotFound();
    else return updatedMovie;
  }

  [HttpDelete("delete/{id}")]
  public ActionResult<Movie> DeleteMovie(int id)
  {
    Movie? updatedMovie = db.Delete(id);
    if (updatedMovie == null) return NotFound();
    else return updatedMovie;
  }
}
