using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using parcial1.Models;
using parcial1.Services;

namespace parcial1.Controllers;

public class AppointmentController : Controller
{
  private readonly IDatabase db;

  public AppointmentController(IDatabase db)
  {
    this.db = db;
  }

  public IActionResult Index()
  {
    List<Appointment> apps = db.getAllAppinmets();
    return View(apps);
  }

  public IActionResult Edit(Appointment app, string actionType)
  {
    ViewBag.actionType = actionType;
    return View(app);
  }

  public IActionResult CreateAppointment()
  {
    return RedirectToAction("Edit", new { app = new Appointment(), actionType = "CreateAppointment" });
  }

  [HttpPost]
  public IActionResult CreateAppointment(Appointment app)
  {
    db.InsertAppointment(app);
    return RedirectToAction("Index");
  }

  public IActionResult UpdateAppointment(Appointment _app)
  {
    return RedirectToAction("Edit", new { 
      Id = _app.Id,
      PersonalInformationPatientId = _app.PersonalInformationPatientId,
      PersonalInformationDoctorId = _app.PersonalInformationDoctorId,
      AppointmentDate = _app.AppointmentDate,
      AppointmentTime = _app.AppointmentTime,
      actionType = "UpdateAppointmentPost" 
    });
  }

  [HttpPost]
  public IActionResult UpdateAppointmentPost(Appointment app)
  {
    db.UpdateAppointment(app);
    return RedirectToAction("Index");
  }

  public IActionResult DeleteAppointment(Appointment app)
  {
    db.DeleteAppointment(app.Id);
    return RedirectToAction("Index");
  }


  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}