using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using admin.Models;

namespace admin.Controllers;

public class ServicesController : Controller
{
    private readonly ILogger<ServicesController> _logger;

    public ServicesController(ILogger<ServicesController> logger)
    {
        _logger = logger;
    }

    public IActionResult CreatePost()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
