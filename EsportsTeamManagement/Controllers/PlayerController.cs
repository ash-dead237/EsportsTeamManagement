using Microsoft.AspNetCore.Mvc;
using EsportsTeamManagement.Services; 
using EsportsTeamManagement.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using EsportsTeamManagement.Models;

namespace EsportsTeamManagement.Controllers
{
    public class PlayerController : Controller
    {
        // 1. Declare BOTH private fields together at the top
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;

        // 2. Inject BOTH dependencies inside a single constructor
        public PlayerController(
            IPlayerService playerService,
            ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }

        // GET: /Player/Index
        public IActionResult Index()
        {
            var players = _playerService.GetPlayers();
            return View(players);
        }

        // GET: /Player/Create
        [HttpGet]
        public IActionResult Create()
        {
            var teams = _teamService.GetTeams();

            PlayerViewModel model = new PlayerViewModel
            {
                Teams = teams.Select(t => new SelectListItem
                {
                    Value = t.TeamId.ToString(),
                    Text = t.TeamName
                }).ToList()
            };

            return View(model);
        }

        // POST: /Player/Create
        [HttpPost]
        public IActionResult Create(PlayerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Teams = _teamService.GetTeams()
                    .Select(t => new SelectListItem
                    {
                        Value = t.TeamId.ToString(),
                        Text = t.TeamName
                    }).ToList();

                return View(model);
            }

            Player player = new Player
            {
                PlayerName = model.PlayerName,
                Age = model.Age,
                Country = model.Country,
                GameRole = model.GameRole,
                PlayerRank = model.PlayerRank,
                TeamId = model.TeamId
            };

            _playerService.AddPlayer(player);

            return RedirectToAction("Index");
        }

        // 👇 Added: GET action to display the player Edit form with populated team selections
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var player = _playerService.GetPlayerById(id);

            if (player == null)
            {
                return NotFound();
            }

            var teams = _teamService.GetTeams();

            PlayerViewModel model = new PlayerViewModel
            {
                PlayerName = player.PlayerName,
                Age = player.Age??0,
                Country = player.Country,
                GameRole = player.GameRole,
                PlayerRank = player.PlayerRank,
                TeamId = player.TeamId??0,
                Teams = teams.Select(t => new SelectListItem
                {
                    Value = t.TeamId.ToString(),
                    Text = t.TeamName
                }).ToList()
            };

            return View(model);
        }

        // 👇 Added: POST action to save the edited player data back to the database
        [HttpPost]
        public IActionResult Edit(int id, PlayerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Teams = _teamService.GetTeams()
                    .Select(t => new SelectListItem
                    {
                        Value = t.TeamId.ToString(),
                        Text = t.TeamName
                    }).ToList();

                return View(model);
            }

            var player = _playerService.GetPlayerById(id);

            if (player == null)
            {
                return NotFound();
            }

            player.PlayerName = model.PlayerName;
            player.Age = model.Age;
            player.Country = model.Country;
            player.GameRole = model.GameRole;
            player.PlayerRank = model.PlayerRank;
            player.TeamId = model.TeamId;

            _playerService.UpdatePlayer(player);

            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            var player = _playerService.GetPlayerById(id);

            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            _playerService.DeletePlayer(id);

            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Details(int id)
        {
            var player = _playerService.GetPlayerById(id);

            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

    }
}
