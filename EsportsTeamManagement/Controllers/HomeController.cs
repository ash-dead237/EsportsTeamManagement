using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EsportsTeamManagement.Models;
namespace EsportsTeamManagement.Controllers;

public class HomeController : Controller
{
    // 1. Declare a private field to store the database context    // 1. Declare a private field to store the database context
    private readonly EsportsTeamManagementDbContext _context;

    // 2. Inject the database context through the constructor
    public HomeController(EsportsTeamManagementDbContext context)
    {
        _context = context;
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // 3. Your temporary test action
    public IActionResult Test()
    {
        try
        {
            var count = _context.Players.Count();
            return Content($"Players Count : {count}");
        }
        catch (Exception ex)
        {
            // Catches and displays connection errors (like wrong server name or missing migrations)
            return Content($"Database Connection Failed: {ex.Message}");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
