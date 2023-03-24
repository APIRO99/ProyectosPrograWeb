
using backend.models;
using modelos.models;

namespace backend.Services.Database;

public class Database : IDatabase {

  PrograWebContext dbcontext;
  public Database(){
    dbcontext = new PrograWebContext();
  }

  public List<Movie> ObtienePeliculas(){
    return dbcontext.Movies.ToList();
  }

  public List<Category> ObtieneCategorias(){
    return dbcontext.Categories.ToList();
  }
}