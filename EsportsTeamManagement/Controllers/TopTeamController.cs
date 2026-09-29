using EsportsTeamManagement.Services;
using Microsoft.AspNetCore.Mvc;

public class TopTeamsController : Controller
{
    private readonly IDashboardService _dashboardService;

    public TopTeamsController(
        IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public IActionResult Index()
    {
        var teams = _dashboardService.GetTopTeams();

        return View(teams);
    }
}