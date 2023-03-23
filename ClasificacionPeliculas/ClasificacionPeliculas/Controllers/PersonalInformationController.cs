using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClasificacionPeliculas.Context;
using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace ClasificacionPeliculas.Controllers
{
  public class PersonalInformationController : Controller
  {
    private readonly MoviesContext _context;
    private readonly IPersonalInformationsService ps;

    public PersonalInformationController(IPersonalInformationsService ps)
    {
      this.ps = ps;
      _context = new MoviesContext();
    }

    // GET: PersonalInformations
    public async Task<IActionResult> Index()
    {
      IEnumerable<PersonalInformation> _personalInformations = await ps.GetPersonalInformations();
      return View(_personalInformations);
    }

    // GET: PersonalInformation/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.PersonalInformations == null) return NotFound();
      var personalInformations = await GetPersonalInformationWithCity(id);
      if (personalInformations == null) return NotFound();
      return View(personalInformations);
    }

    // GET: PersonalInformation/Create
    public async Task<IActionResult> Create()
    {
      List<Region> regions = GetRegions();
      List<City> cities = (List<City>)GetCitiesFromRegion(regions[0].Geonameid).Value;
      ViewBag.regions = new SelectList(regions, "Geonameid", "Name", regions.Select(s => s.Geonameid).FirstOrDefault());
      ViewBag.cities = new SelectList(cities, "Geonameid", "Name", cities.Select(s => s.Geonameid).FirstOrDefault());
      return View();
    }


    // POST: PersonalInformation/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,DateOfBirth,Email,PhoneNumber,Address,GeonameidCity")] PersonalInformation PersonalInformation)
    {
      if (!ModelState.IsValid) return View(PersonalInformation);
      await ps.CreatePersonalInformation(PersonalInformation);
      return RedirectToAction(nameof(Index));
    }

    // GET: PersonalInformation/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _context.PersonalInformations == null) return NotFound();
      var personalInformations = await GetPersonalInformationWithCity(id);
      if (personalInformations == null) return NotFound();

      List<Region> regions = GetRegions();
      SelectList regionsList = new SelectList(regions, "Geonameid", "Name", regions.Select(s => s.Geonameid).FirstOrDefault());
      regionsList.Where(x => x.Value == personalInformations.GeonameidCityNavigation.GeonameidRegion.ToString()).First().Selected = true;
      ViewBag.regions = regionsList;

      List<City> cities = (List<City>)GetCitiesFromRegion(personalInformations.GeonameidCityNavigation.GeonameidRegion).Value;
      ViewBag.cities = new SelectList(cities, "Geonameid", "Name", cities.Select(s => s.Geonameid).FirstOrDefault());

      return View(personalInformations);
    }

    // POST: PersonalInformation/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateOfBirth,Email,PhoneNumber,Address,GeonameidCity")] PersonalInformation PersonalInformation)
    {
      if (id != PersonalInformation.Id) return NotFound();
      if (!ModelState.IsValid) View(PersonalInformation);
      await ps.UpdatePersonalInformation(PersonalInformation);
      return RedirectToAction(nameof(Index));
    }

    // GET: PersonalInformation/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _context.PersonalInformations == null) return NotFound();
      var personalInformations = await GetPersonalInformationWithCity(id);
      if (personalInformations == null) return NotFound();
      return View(personalInformations);
    }

    // POST: PersonalInformation/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.PersonalInformations == null)
        return Problem("Entity set 'MoviesContext.PersonalInformations'  is null.");

      var personalInformations = await _context.PersonalInformations.FindAsync(id);
      if (personalInformations != null) _context.PersonalInformations.Remove(personalInformations);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private List<Region> GetRegions()
    {
      return (
        from r in _context.Regions
        select new Region
        {
          Geonameid = r.Geonameid,
          Name = r.Name
        }
      )
      .OrderBy(r => r.Name)
      .ToList();
    }

    private async Task<PersonalInformation> GetPersonalInformationWithCity(int? id)
    {
      if (id == null) return null;
      return await ps.GetPersonalInformation((int)id);
    }

    // AUX ------------------------------------------------------------------------

    public JsonResult GetCitiesFromRegion(long regionID)
    {
      List<City> cities = (
        from c in _context.Cities
        where c.GeonameidRegion == regionID
        select new City
        {
          Geonameid = c.Geonameid,
          Name = c.Name
        }
      )
      .OrderBy(r => r.Name)
      .ToList();
      return Json(cities);
    }
  }
}
