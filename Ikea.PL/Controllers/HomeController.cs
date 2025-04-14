using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ikea.PL.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ikea.PL.Controllers;

//[AllowAnonymous]
[Authorize] //he should has a token to enter
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger; //this will log errors 

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(); //search as default on -view start
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
