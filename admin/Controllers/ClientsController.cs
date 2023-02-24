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


  public IActionResult Edit(Client client)
  {
    return View(client);
  }

  [HttpPost]
  public IActionResult PostClient(Client client)
  {
    mysql.updateClient(client);
    return View("Index", mysql.getClients());
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
