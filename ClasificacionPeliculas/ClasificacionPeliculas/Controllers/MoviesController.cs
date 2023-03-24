using Microsoft.AspNetCore.Mvc;
using ClasificacionPeliculasModel;

namespace ClasificacionPeliculas.Controllers
{
  public class MoviesController : Controller
  {
    private readonly IMoviesService ms;

    public MoviesController(IMoviesService ms)
    {
      this.ms = ms;
    }

    // GET: Movies
    public async Task<IActionResult> Index()
    {
      return View(await ms.GetMovies());
    }

    // GET: Movies/Details/5
    public async Task<IActionResult> Details(int id)
    {
      var movie = await getMoviesWithVotes(id);
      if (movie == null) return NotFound();
      return View(movie);
    }

    // GET: Movies/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Duration,Director,Actors,Plot,Rating,Votes,PosterUrl,ImdbId")] Movie movie)
    {
      if (ModelState.IsValid)
      {
        await ms.CreateMovie(movie);
        return RedirectToAction(nameof(Index));
      }
      return View(movie);
    }

    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      var movie = await getMoviesWithVotes((int)id);
      if (movie == null) return NotFound();
      return View(movie);
    }

    // POST: Movies/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Duration,Director,Actors,Plot,Rating,Votes,PosterUrl,ImdbId")] ClasificacionPeliculasModel.Movie movie)
    {
      if (!ModelState.IsValid) return View(movie);
      await ms.UpdateMovie(movie);
      return RedirectToAction(nameof(Index));
    }


    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var movie = await getMoviesWithVotes(id);
      if (movie == null) return NotFound();
      return View(movie);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await ms.DeleteMovie(id);
      return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<JsonResult> GetMovieJson()
    {
      int movieId = Convert.ToInt32(HttpContext.Request.Form["movieId"].FirstOrDefault().ToString());
      return Json(new { movie = await getMoviesWithVotes((int)movieId) });
    }

    // Helpers 
    private async Task<Movie> getMoviesWithVotes(int id)
    {
      return await ms.GetMovie((int)id);
    }
  }
}
