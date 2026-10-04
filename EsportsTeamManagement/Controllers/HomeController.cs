using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EsportsTeamManagement.Models;
using EsportsTeamManagement.Services;

namespace EsportsTeamManagement.Controllers;

public class HomeController : Controller
{
    // 1. Declare BOTH private fields together at the top
    private readonly EsportsTeamManagementDbContext _context;
    private readonly IPlayerService _playerService;
    
    // 2. Inject BOTH dependencies inside a single constructor
    public HomeController(EsportsTeamManagementDbContext context, IPlayerService playerService)
    {
        _context = context;
        _playerService = playerService;
    }

    // 3. Your action method to test the service layer
    public IActionResult Players()
    {
        var players = _playerService.GetPlayers();
        return Json(players);
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // 4. Your temporary database test action
    public IActionResult Test()
    {
        try
        {
            var count = _context.Players.Count();
            return Content($"Players Count : {count}");
        }
        catch (Exception ex)
        {
            return Content($"Database Connection Failed: {ex.Message}");
        }
    }
//below action method is used to handle errors and display an error view with relevant information.
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
