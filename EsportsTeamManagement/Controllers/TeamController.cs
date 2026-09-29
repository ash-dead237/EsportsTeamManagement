using Microsoft.AspNetCore.Mvc;
using EsportsTeamManagement.Services;      // Ensures ITeamService can be found
using EsportsTeamManagement.Models;        // Ensures Team can be found
using EsportsTeamManagement.ViewModels;    // Ensures TeamViewModel can be found

namespace EsportsTeamManagement.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // GET: /Team/Index
        public IActionResult Index()
        {
            var teams = _teamService.GetTeams();
            return View(teams);
        }

        // GET: /Team/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Team/Create
        [HttpPost]
        public IActionResult Create(TeamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Team team = new Team
            {
                TeamName = model.TeamName,
                Region = model.Region,
                CoachId = model.CoachId,
                CreatedDate = DateTime.Now
            };

            _teamService.AddTeam(team);

            return RedirectToAction("Index");
        }

        // 👇 Added: GET action to fetch team details and display the Edit form page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var team = _teamService.GetTeamById(id);

            if (team == null)
            {
                return NotFound();
            }

            TeamViewModel model = new TeamViewModel
            {
                TeamName = team.TeamName,
                Region = team.Region,
                CoachId = team.CoachId
            };

            return View(model);
        }
        [HttpPost]

        public IActionResult Edit(int id, TeamViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var team = _teamService.GetTeamById(id);

            if (team == null)
                return NotFound();

            team.TeamName = model.TeamName;
            team.Region = model.Region;
            team.CoachId = model.CoachId;

            _teamService.UpdateTeam(team);

            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            var team = _teamService.GetTeamById(id);

            if (team == null)
                return NotFound();

            return View(team);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            _teamService.DeleteTeam(id);

            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Details(int id)
        {
            var team = _teamService.GetTeamById(id);

            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }
    }
}
