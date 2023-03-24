
using api.Context;
using ClasificacionPeliculasModel;

namespace api.Services;

public interface IGeographicService
{
  public List<Region> GetRegions();
  public List<City> GetCitiesFromRegion(int regionID);
}

public class GeographicService : IGeographicService
{
    private MoviesContext dbContext;
  public GeographicService(MoviesContext dbContext)
  {
    this.dbContext = dbContext;
  }
  public List<Region> GetRegions()
  {
    return (
      from r in dbContext.Regions
      select new Region
      {
        Geonameid = r.Geonameid,
        Name = r.Name
      }
    )
    .OrderBy(r => r.Name)
    .ToList();
  }

  public List<City> GetCitiesFromRegion(int regionID)
  {
    return (
      from c in dbContext.Cities
      where c.GeonameidRegion == regionID
      select new City
      {
        Geonameid = c.Geonameid,
        Name = c.Name
      }
    )
    .OrderBy(r => r.Name)
    .ToList();
  }
}