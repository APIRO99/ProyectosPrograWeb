using backend.Services.Database;
using Microsoft.AspNetCore.Mvc;
using modelos.models;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    IDatabase db;

    public MoviesController(IDatabase _db)
    {
        this.db = _db;
    }

    public List<Movie> Get() {
        return db.ObtienePeliculas();
    }


}
