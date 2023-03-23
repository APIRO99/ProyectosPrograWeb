
using api.Context;
using ClasificacionPeliculasModel;

namespace api.Services;

public class PersonalInformationService : IDatabaseService<PersonalInformation, int>
{
  private MoviesContext dbContext;
  public PersonalInformationService(MoviesContext dbContext)
  {
    this.dbContext = dbContext;
  }

  public PersonalInformation Create(PersonalInformation entity)
  {
    dbContext.PersonalInformations.Add(entity);
    dbContext.SaveChanges();
    return entity;
  }

  public PersonalInformation? Delete(int id)
  {
    PersonalInformation? personalinformation = dbContext.PersonalInformations.FirstOrDefault(s => s.Id == id);
    if (personalinformation == null) return null;
    dbContext.PersonalInformations.Remove(personalinformation);
    dbContext.SaveChanges();
    return personalinformation;
  }

  public List<PersonalInformation> GetAll()
  {
    return (from pi in dbContext.PersonalInformations
            join c in dbContext.Cities on pi.GeonameidCity equals c.Geonameid
            select new PersonalInformation
            {
              Id = pi.Id,
              Name = pi.Name,
              DateOfBirth = pi.DateOfBirth,
              Email = pi.Email,
              PhoneNumber = pi.PhoneNumber,
              Address = pi.Address,
              GeonameidCity = pi.GeonameidCity,
              GeonameidCityNavigation = new City()
              {
                Name = c.Name
              }
            }).ToList();
  }

  public PersonalInformation? GetOne(int id)
  {
    return (from pi in dbContext.PersonalInformations
            join c in dbContext.Cities on pi.GeonameidCity equals c.Geonameid
            where pi.Id == id
            select new PersonalInformation
            {
              Id = pi.Id,
              Name = pi.Name,
              DateOfBirth = pi.DateOfBirth,
              Email = pi.Email,
              PhoneNumber = pi.PhoneNumber,
              Address = pi.Address,
              GeonameidCity = pi.GeonameidCity,
              GeonameidCityNavigation = new City()
              {
                Name = c.Name,
                GeonameidRegion = c.GeonameidRegion
              }
            }).FirstOrDefault();
  }

  public PersonalInformation? Update(PersonalInformation entity)
  {
    PersonalInformation? personalinformation = dbContext.PersonalInformations.FirstOrDefault(s => s.Id == entity.Id);
    if (personalinformation == null) return null;
    personalinformation.GeonameidCity = entity.GeonameidCity;
    personalinformation.Name = entity.Name;
    personalinformation.DateOfBirth = entity.DateOfBirth;
    personalinformation.Email = entity.Email;
    personalinformation.PhoneNumber = entity.PhoneNumber;
    personalinformation.Address = entity.Address;
    dbContext.PersonalInformations.Update(personalinformation);
    dbContext.SaveChanges();
    return personalinformation;
  }
}