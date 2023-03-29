
using backend.Context;
using backend.Models;

namespace backend.Services;

public interface IPropertyService: IBaseCrud<Property, int> { }

public class PropertyService : IPropertyService
{
  private readonly PropiedadesDelBosqueContext dbContext = new PropiedadesDelBosqueContext();

  public Property Create(Property entity)
  {
    dbContext.Properties.Add(entity);
    dbContext.SaveChanges();
    return entity;
  }

  public Property? Delete(int id)
  {
    Property? Property = dbContext.Properties.Find(id);
    if (Property == null) return null;
    dbContext.Properties.Remove(Property);
    dbContext.SaveChanges();
    return Property;
  }

  public List<Property> GetAll()
  {
    return dbContext.Properties.ToList();
  }

  public Property? GetOne(int id)
  {
    return (
      from c in dbContext.Properties
      where c.Id == id
      select new Property() {
        Id = c.Id,
        Address = c.Address,
        City = c.City,
        Name = c.Name,
        Photo = c.Photo,
        State = c.State,
        Status = c.Status
      }
    ).FirstOrDefault();
  }

  public Property? Update(Property entity)
  {
    Property? Property = dbContext.Properties.Find(entity.Id);
    if (Property == null) return null;
    Property.Address = entity.Address;
    Property.City = entity.City;
    Property.Name = entity.Name;
    Property.Photo = entity.Photo;
    Property.State = entity.State;
    Property.Status = entity.Status;
    dbContext.SaveChanges();
    return Property;
  }
}
