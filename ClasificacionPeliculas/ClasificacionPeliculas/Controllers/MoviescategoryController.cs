using ClasificacionPeliculas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClasificacionPeliculas.Controllers
{
  public class MoviescategoryController : Controller
  {
    private readonly MoviesContext _context;

    public MoviescategoryController()
    {
      _context = new MoviesContext();
    }
    public IActionResult Index()
    {
      IEnumerable<ClasificacionPeliculasModel.Moviescategory> moviescategories =
          (from mc in _context.Moviescategories
           join m in _context.Movies on mc.MovieId equals m.Id
           join c in _context.Categories on mc.CategoryId equals c.Id
           select new ClasificacionPeliculasModel.Moviescategory
           {
             Id = mc.Id,
             MovieName = m.Title,
             CategoryName = c.Name
           }).ToList();
      return View(moviescategories);
    }

    public IActionResult Create()
    {
      MoviesContext _context = new MoviesContext();
      IEnumerable<ClasificacionPeliculasModel.Movie> movies = (from mc in _context.Movies
                                                               select new ClasificacionPeliculasModel.Movie
                                                               {
                                                                 Id = mc.Id,
                                                                 Title = mc.Title,
                                                               }).ToList();
      IEnumerable<ClasificacionPeliculasModel.Category> categories = (from c in _context.Categories
                                                                      select new ClasificacionPeliculasModel.Category
                                                                      {
                                                                        Id = c.Id,
                                                                        Name = c.Name
                                                                      }).ToList();
      ClasificacionPeliculasModel.Moviescategory moviescategory = new ClasificacionPeliculasModel.Moviescategory();
      moviescategory.Categories = categories.Select(s => new SelectListItem()
      {
        Value = s.Id.ToString(),
        Text = s.Name
      }).ToList();
      moviescategory.Movies = movies.Select(s => new SelectListItem()
      {
        Value = s.Id.ToString(),
        Text = s.Title
      }).ToList();
      return View(moviescategory);
    }
    [HttpPost]
    public IActionResult Create(int MovieId, int CategoryId)
    {
      Models.Moviescategory moviescategory = new Moviescategory
      {
        MovieId = MovieId,
        CategoryId = CategoryId
      };
      MoviesContext _context = new MoviesContext();
      _context.Moviescategories.Add(moviescategory);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    // GET: Movies/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.Movies == null)
      {
        return NotFound();
      }

      var movie = (from mc in _context.Moviescategories
                   join m in _context.Movies on mc.MovieId equals m.Id
                   join c in _context.Categories on mc.CategoryId equals c.Id
                   select new ClasificacionPeliculasModel.Moviescategory
                   {
                     Id = mc.Id,
                     MovieName = m.Title,
                     CategoryName = c.Name
                   }).FirstOrDefault(m => m.Id == id);
      if (movie == null)
      {
        return NotFound();
      }

      return View(movie);
    }


    // EDIT ======================================================================
    // ===========================================================================

    [HttpGet]
    public IActionResult Edit(int id)
    {
      var moviescategory = (from mc in _context.Moviescategories
                            join m in _context.Movies on mc.MovieId equals m.Id
                            join c in _context.Categories on mc.CategoryId equals c.Id
                            select new ClasificacionPeliculasModel.Moviescategory
                            {
                              Id = mc.Id,
                              MovieName = m.Title,
                              MovieId = m.Id,
                              CategoryName = c.Name,
                              CategoryId = c.Id
                            }).FirstOrDefault(m => m.Id == id);
      IEnumerable<ClasificacionPeliculasModel.Movie> movies = (from mc in _context.Movies
                                                               select new ClasificacionPeliculasModel.Movie
                                                               {
                                                                 Id = mc.Id,
                                                                 Title = mc.Title,
                                                               }).ToList();
      IEnumerable<ClasificacionPeliculasModel.Category> categories = (from c in _context.Categories
                                                                      select new ClasificacionPeliculasModel.Category
                                                                      {
                                                                        Id = c.Id,
                                                                        Name = c.Name
                                                                      }).ToList();
      moviescategory.Categories = categories.Select(s => new SelectListItem()
      {
        Value = s.Id.ToString(),
        Text = s.Name
      }).ToList();
      moviescategory.Movies = movies.Select(s => new SelectListItem()
      {
        Value = s.Id.ToString(),
        Text = s.Title
      }).ToList();

      return View(moviescategory);
    }

    [HttpPost]
    public IActionResult Edit(int id, int MovieId, int CategoryId)
    {
      MoviesContext _moviesContext = new MoviesContext();
      Models.Moviescategory category = _moviesContext.Moviescategories.FirstOrDefault(s => s.Id == id);
      category.CategoryId = CategoryId;
      category.MovieId = MovieId;

      _moviesContext.Moviescategories.Update(category);
      _moviesContext.SaveChanges();

      return RedirectToAction("Index");
    }


    // DELETE ====================================================================
    // ===========================================================================

    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      var moviescategory = (from mc in _context.Moviescategories
                            join m in _context.Movies on mc.MovieId equals m.Id
                            join c in _context.Categories on mc.CategoryId equals c.Id
                            select new ClasificacionPeliculasModel.Moviescategory
                            {
                              Id = mc.Id,
                              MovieName = m.Title,
                              MovieId = m.Id,
                              CategoryName = c.Name,
                              CategoryId = c.Id
                            }).FirstOrDefault(m => m.Id == id);
      IEnumerable<ClasificacionPeliculasModel.Movie> movies = (from mc in _context.Movies
                                                               select new ClasificacionPeliculasModel.Movie
                                                               {
                                                                 Id = mc.Id,
                                                                 Title = mc.Title,
                                                               }).ToList();
      IEnumerable<ClasificacionPeliculasModel.Category> categories = (from c in _context.Categories
                                                                      select new ClasificacionPeliculasModel.Category
                                                                      {
                                                                        Id = c.Id,
                                                                        Name = c.Name
                                                                      }).ToList();
      moviescategory.Categories = categories.Select(s => new SelectListItem()
      {
        Value = s.Id.ToString(),
        Text = s.Name
      }).ToList();
      moviescategory.Movies = movies.Select(s => new SelectListItem()
      {
        Value = s.Id.ToString(),
        Text = s.Title
      }).ToList();

      return View(moviescategory);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.Movies == null)
      {
        return Problem("Entity set 'MoviesContext.Movies'  is null.");
      }

      var movie = await _context.Moviescategories.FindAsync(id);
      if (movie != null)
      {
        _context.Moviescategories.Remove(movie);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool MovieExists(int id)
    {
      return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
    }

  }
}
