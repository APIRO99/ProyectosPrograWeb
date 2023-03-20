using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc;
using api.Services;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonalInformationController : ControllerBase
{
  private IDatabaseService<PersonalInformation, int> db;
  public PersonalInformationController(IDatabaseService<PersonalInformation, int> _db)
  {
    this.db = _db;
  }


  [HttpGet("")]
  public ActionResult<List<PersonalInformation>> getAll()
  {
    return db.GetAll();
  }

  [HttpPost("create")]
  public ActionResult<PersonalInformation> CreatePersonalInformation(PersonalInformation body)
  {
    return db.Create(body);
  }

  [HttpGet("{id}")]
  public ActionResult<PersonalInformation> GetPersonalInformation(int id)
  {
    PersonalInformation? updatedPersonalInformation = db.Delete(id);
    if (updatedPersonalInformation == null) return NotFound();
    else return updatedPersonalInformation;
  }

  [HttpPut("update")]
  public ActionResult<PersonalInformation> UpdatePersonalInformation(PersonalInformation body)
  {
    PersonalInformation? updatedPersonalInformation = db.Update(body);
    if (updatedPersonalInformation == null) return NotFound();
    else return updatedPersonalInformation;
  }

  [HttpDelete("delete/{id}")]
  public ActionResult<PersonalInformation> DeletePersonalInformation(int id)
  {
    PersonalInformation? updatedPersonalInformation = db.Delete(id);
    if (updatedPersonalInformation == null) return NotFound();
    else return updatedPersonalInformation;
  }
}
