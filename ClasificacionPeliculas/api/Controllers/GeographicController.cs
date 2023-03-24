using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc;
using api.Services;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class GeoGraphicController : ControllerBase
{
  private IGeographicService db;
  public GeoGraphicController(IGeographicService _db)
  {
    this.db = _db;
  }

  [HttpGet("GetRegions/")]
  public ActionResult<List<Region>> GetRegions()
  {
    List<Region>? regions = db.GetRegions();
    if (regions == null) return NotFound();
    else return regions;
  }


  [HttpGet("GetCitiesFromRegion/{idRegion}")]
  public ActionResult<List<City>> GetCitiesFromRegion(int idRegion)
  {
    List<City>? cities = db.GetCitiesFromRegion(idRegion);
    if (cities == null) return NotFound();
    else return cities;
  }

}
