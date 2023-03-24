
using api.Context;
using ClasificacionPeliculasModel;

namespace api.Services;

public class MoviescategoryService : IDatabaseService<Moviescategory, int>
{
  private MoviesContext dbContext;
  public MoviescategoryService(MoviesContext dbContext)
  {
    this.dbContext = dbContext;
  }

  public Moviescategory Create(Moviescategory entity)
  {
    entity.Id = 0;
    dbContext.Moviescategories.Add(entity);
    dbContext.SaveChanges();
    return entity;
  }

  public Moviescategory? Delete(int id)
  {
    Moviescategory? Moviescategory = dbContext.Moviescategories.FirstOrDefault(s => s.Id == id);
    if (Moviescategory == null) return null;
    dbContext.Moviescategories.Remove(Moviescategory);
    dbContext.SaveChanges();
    return Moviescategory;
  }

  public List<Moviescategory> GetAll()
  {
    return (from mc in dbContext.Moviescategories
            join m in dbContext.Movies on mc.MovieId equals m.Id
            join c in dbContext.Categories on mc.CategoryId equals c.Id
            select new Moviescategory
            {
              Id = mc.Id,
              MovieName = m.Title,
              CategoryName = c.Name
            }).ToList();
  }

  public Moviescategory? GetOne(int id)
  {
    return dbContext.Moviescategories.FirstOrDefault(s => s.Id == id);
  }

  public Moviescategory? Update(Moviescategory entity)
  {
    Moviescategory? Moviescategory = dbContext.Moviescategories.FirstOrDefault(s => s.Id == entity.Id);
    if (Moviescategory == null) return null;
    Moviescategory.MovieId = entity.MovieId;
    Moviescategory.CategoryId = entity.CategoryId;
    dbContext.Moviescategories.Update(Moviescategory);
    dbContext.SaveChanges();
    return Moviescategory;
  }
}