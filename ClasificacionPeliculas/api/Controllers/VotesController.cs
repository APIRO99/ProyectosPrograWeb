using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc;
using api.Services;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class VoteController : ControllerBase
{
  private IDatabaseService<Vote, int> db;
  public VoteController(IDatabaseService<Vote, int> _db)
  {
    this.db = _db;
  }


  [HttpGet("")]
  public ActionResult<List<Vote>> getAll()
  {
    return db.GetAll();
  }

  [HttpPost("create")]
  public ActionResult<Vote> CreateVote(Vote body)
  {
    return db.Create(body);
  }

  [HttpGet("{id}")]
  public ActionResult<Vote> GetVote(int id)
  {
    Vote? updatedVote = db.GetOne(id);
    if (updatedVote == null) return NotFound();
    else return updatedVote;
  }

  [HttpPut("update")]
  public ActionResult<Vote> UpdateVote(Vote body)
  {
    Vote? updatedVote = db.Update(body);
    if (updatedVote == null) return NotFound();
    else return updatedVote;
  }

  [HttpDelete("delete/{id}")]
  public ActionResult<Vote> DeleteVote(int id)
  {
    Vote? updatedVote = db.Delete(id);
    if (updatedVote == null) return NotFound();
    else return updatedVote;
  }
}
