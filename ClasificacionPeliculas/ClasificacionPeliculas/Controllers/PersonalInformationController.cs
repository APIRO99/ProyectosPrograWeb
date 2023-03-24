using Microsoft.AspNetCore.Mvc;
using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClasificacionPeliculas.Controllers
{
  public class PersonalInformationController : Controller
  {
    private readonly IPersonalInformationsService ps;
    private readonly IGeographicService gs;

    public PersonalInformationController(IPersonalInformationsService ps, IGeographicService gs)
    {
      this.ps = ps;
      this.gs = gs;
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
      var personalInformations = await GetPersonalInformationWithCity(id);
      if (personalInformations == null) return NotFound();
      return View(personalInformations);
    }

    // GET: PersonalInformation/Create
    public async Task<IActionResult> Create()
    {
      List<Region> regions = await GetRegions();
      List<City> cities = (List<City>) (await GetCitiesFromRegion(regions[0].Geonameid)).Value;
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
      var personalInformations = await GetPersonalInformationWithCity(id);
      if (personalInformations == null) return NotFound();

      List<Region> regions = await GetRegions();
      SelectList regionsList = new SelectList(regions, "Geonameid", "Name", regions.Select(s => s.Geonameid).FirstOrDefault());
      regionsList.Where(x => x.Value == personalInformations.GeonameidCityNavigation.GeonameidRegion.ToString()).First().Selected = true;
      ViewBag.regions = regionsList;

      List<City> cities = (List<City>) (await GetCitiesFromRegion(personalInformations.GeonameidCityNavigation.GeonameidRegion)).Value;
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
      var personalInformations = await GetPersonalInformationWithCity(id);
      if (personalInformations == null) return NotFound();
      return View(personalInformations);
    }

    // POST: PersonalInformation/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await ps.DeletePersonalInformation(id);
      return RedirectToAction(nameof(Index));
    }

    private async Task<List<Region>> GetRegions()
    {
      return (await gs.GetRegions()).ToList();
    }

    private async Task<PersonalInformation> GetPersonalInformationWithCity(int? id)
    {
      if (id == null) return null;
      return await ps.GetPersonalInformation((int)id);
    }

    // AUX ------------------------------------------------------------------------

    public async Task<JsonResult> GetCitiesFromRegion(long regionID)
    {
      return Json((await gs.GetCitiesFromRegion((int)regionID)).ToList());
    }
  }
}
