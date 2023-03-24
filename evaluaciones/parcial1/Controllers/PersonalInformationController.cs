using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using parcial1.Models;
using parcial1.Services;

namespace parcial1.Controllers;

public class PersonalInformationController : Controller
{
  private readonly IDatabase db;

  public PersonalInformationController(IDatabase db)
  {
    this.db = db;
  }

  public IActionResult Index()
  {
    List<PersonalInformation> pi = db.getAllPersons();
    return View(pi);
  }

  public IActionResult Edit(PersonalInformation pi, string actionType)
  {
    ViewBag.actionType = actionType;
    return View(pi);
  }

  public IActionResult CreatePersonalInformation()
  {
    return RedirectToAction("Edit", new { pi = new PersonalInformation(), actionType = "CreatePersonalInformation" });
  }

  [HttpPost]
  public IActionResult CreatePersonalInformation(PersonalInformation pi)
  {
    db.InsertPersonalInformation(pi);
    return RedirectToAction("Index");
  }

  public IActionResult UpdatePersonalInformation(PersonalInformation _pi)
  {
    return RedirectToAction("Edit", new { 
      Id = _pi.Id,
      Name = _pi.Name,
      DateOfBirth = _pi.DateOfBirth,
      Email = _pi.Email,
      PhoneNumber = _pi.PhoneNumber,
      Address = _pi.Address,
      actionType = "UpdatePersonalInformationPost" 
    });
  }

  [HttpPost]
  public IActionResult UpdatePersonalInformationPost(PersonalInformation pi)
  {
    db.UpdatePersonalInformation(pi);
    return RedirectToAction("Index");
  }

  // [HttpPost]
  public IActionResult DeletePersonalInformation(PersonalInformation pi)
  {
    db.DeletePersonalInformation(pi.Id);
    return RedirectToAction("Index");
  }


  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
