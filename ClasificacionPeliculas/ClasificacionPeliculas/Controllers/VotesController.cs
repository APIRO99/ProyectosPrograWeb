using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClasificacionPeliculas.Controllers
{
  public class VotesController : Controller
  {
    private readonly IVotesService vs;
    private readonly IPersonalInformationsService ps;
    private readonly IMoviesService ms;

    public VotesController(IVotesService vs, IPersonalInformationsService ps, IMoviesService ms)
    {
      this.vs = vs;
      this.ps = ps;
      this.ms = ms;
    }

    // GET: Votess
    public async Task<IActionResult> Index()
    {
      IEnumerable<Vote> _votes = await vs.GetVotos();
      return View(_votes);
    }

    // GET: Vote/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      var vote = await vs.GetVoto((int)id);
      if (vote == null) return NotFound();
      return View(vote);
    }

    // GET: Vote/Create
    public async Task<IActionResult> Create()
    {
      List<PersonalInformation> persons = await GetPersons();
      ViewBag.persons = new SelectList(persons, "Id", "Name", persons.Select(s => s.Id).FirstOrDefault());

      List<Movie> cities = (List<Movie>) (await GetUnvotedMovies(persons[0].Id)).Value;
      ViewBag.movies = new SelectList(cities, "Id", "Title", cities.Select(s => s.Id).FirstOrDefault());
      return View();
    }


    // POST: Vote/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PiId,MoviesId,Rate")] Vote Vote)
    {
      if (!ModelState.IsValid) return View(Vote);
      Vote vote = await vs.CreateVoto(Vote);
      return RedirectToAction(nameof(Index));
    }

    // GET: Vote/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      var vote = await vs.GetVoto((int)id);
      if (vote == null) return NotFound();

      List<PersonalInformation> persons = await GetPersons();
      SelectList personsList = new SelectList(persons, "Id", "Name", persons.Select(s => s.Id).FirstOrDefault());
      personsList.Where(x => x.Value == vote.PiId.ToString()).First().Selected = true;
      ViewBag.persons = personsList;

      List<Movie> movies = (List<Movie>) (await GetUnvotedMovies(vote.Pi.Id)).Value;
      movies.Insert(0, vote.Movies);
      ViewBag.movies = new SelectList(movies, "Id", "Title", movies.Select(s => s.Id).FirstOrDefault());

      return View(vote);
    }

    // POST: Vote/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,PiId,MoviesId,Rate,RowCreationTime")] Vote Vote)
    {
      if (id != Vote.Id) return NotFound();
      if (!ModelState.IsValid) View(Vote);
      try
      {
        await vs.UpdateVoto(Vote);
      }
      catch (DbUpdateConcurrencyException) { }
      return RedirectToAction(nameof(Index));
    }

    // GET: Vote/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      var votes = await vs.GetVoto((int)id);
      if (votes == null) return NotFound();
      return View(votes);
    }

    // POST: Vote/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await vs.DeleteVoto(id);
      return RedirectToAction(nameof(Index));
    }

    private async Task<List<PersonalInformation>> GetPersons()
    {
      return (await ps.GetPersonalInformations()).ToList();
    }

    // AUX ------------------------------------------------------------------------

    public async Task<JsonResult> GetUnvotedMovies(long personID)
    {
      return Json(await ms.GetUnvotedMovie((int)personID));
    }
  }
}
