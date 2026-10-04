using Microsoft.AspNetCore.Mvc;
using EsportsTeamManagement.Services;

namespace EsportsTeamManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(
            IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

       /* public IActionResult Index()
        {
            var dashboardData =
                _dashboardService.GetDashboardData();

            return View(dashboardData);
        }
        */
        public IActionResult Index()

        {
    if (HttpContext.Session.GetString("Username") == null)
    {
        return RedirectToAction("Login", "Account");
    }

    var dashboardData =
        _dashboardService.GetDashboardData();

    return View(dashboardData);
}
    }
}