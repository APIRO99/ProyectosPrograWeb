using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using admin.Models;
using admin.Services.Database;

namespace admin.Controllers;

public class ClientsController : Controller
{
  private readonly IDatabase mysql;

  public ClientsController(IDatabase _mysql)
  {
    mysql = _mysql;
  }

  public IActionResult Index()
  {
    List<Client> clients = mysql.getClients();
    return View(clients);
  }


  public IActionResult Form(Client client)
  {
    if (client == null) ViewBag.method = "CreateClient";
    else ViewBag.method = "UpdateClient";
    return View(client);
  }

  public IActionResult CreateClient()
  {
    ViewBag.method = "CreateClient";
    return View("Form", null);
  }

  [HttpPost]
  public IActionResult CreateClient(Client client)
  {
    mysql.createClient(client);
    return View("Index", mysql.getClients());
  }

  [HttpPost]
  public IActionResult UpdateClient(Client client)
  {
    mysql.updateClient(client);
    return View("Index", mysql.getClients());
  }

  public IActionResult DeleteClient(Client client)
  {
    mysql.deleteClient(client.ClientId);
    return View("Index", mysql.getClients());
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
