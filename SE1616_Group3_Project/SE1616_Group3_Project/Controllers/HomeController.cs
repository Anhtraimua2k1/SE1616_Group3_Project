using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SE1616_Group3_Project.Models;

namespace SE1616_Group3_Project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BakingIngredientsContext _context;
    public HomeController(ILogger<HomeController> logger, BakingIngredientsContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
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
