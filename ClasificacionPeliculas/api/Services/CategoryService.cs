
using api.Context;
using ClasificacionPeliculasModel;

namespace api.Services;

public class CategoryService : IDatabaseService<Category, int>
{
  private MoviesContext dbContext;
  public CategoryService(MoviesContext dbContext)
  {
    this.dbContext = dbContext;
  }

  public Category Create(Category entity)
  {
    dbContext.Categories.Add(entity);
    dbContext.SaveChanges();
    return entity;
  }

  public Category? Delete(int id)
  {
    Category? category = dbContext.Categories.FirstOrDefault(s => s.Id == id);
    if (category == null) return null;
    dbContext.Categories.Remove(category);
    dbContext.SaveChanges();
    return category;
  }

  public List<Category> GetAll()
  {
    return dbContext.Categories.ToList();
  }

  public Category? GetOne(int id)
  {
    return dbContext.Categories.FirstOrDefault(s => s.Id == id);
  }

  public Category? Update(Category entity)
  {
    Category? category = dbContext.Categories.FirstOrDefault(s => s.Id == entity.Id);
    if (category == null) return null;
    category.Name = entity.Name;
    dbContext.Categories.Update(category);
    dbContext.SaveChanges();
    return category;
  }
}