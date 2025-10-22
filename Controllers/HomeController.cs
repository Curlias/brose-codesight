using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Brose_OnboardingDashboard.Models;

namespace Brose_OnboardingDashboard.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Redirigir directamente al dashboard de RH (para desarrollo sin autenticación)
        return RedirectToAction("Index", "Dashboard", new { area = "RH" });
        
        // Código original para cuando se habilite autenticación:
        /*
        if (User.Identity?.IsAuthenticated == true)
        {
            if (User.IsInRole("RH") || User.IsInRole("Gerente"))
            {
                return RedirectToAction("Index", "Dashboard", new { area = "RH" });
            }
            else if (User.IsInRole("Empleado"))
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Empleado" });
            }
        }
        
        return View();
        */
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
