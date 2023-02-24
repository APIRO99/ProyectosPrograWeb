
using modelos.models;

namespace backend.Services.Database;

public interface IDatabase {
  public List<Movie> ObtienePeliculas();
  public List<Category> ObtieneCategorias();
}