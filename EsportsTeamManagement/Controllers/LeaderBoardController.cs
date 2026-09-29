using EsportsTeamManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EsportsTeamManagement.Controllers
{
    public class LeaderBoardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public LeaderBoardController(
            IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            var data = _dashboardService.GetLeaderboard();

            return View(data);
        }
    }
}