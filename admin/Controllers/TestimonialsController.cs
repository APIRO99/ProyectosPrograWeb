using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using admin.Models;

namespace admin.Controllers;

public class TestimonialsController : Controller
{
    private readonly ILogger<TestimonialsController> _logger;

    public TestimonialsController(ILogger<TestimonialsController> logger)
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
