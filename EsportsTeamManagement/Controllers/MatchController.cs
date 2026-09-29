using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EsportsTeamManagement.Models;
using EsportsTeamManagement.Services;
using EsportsTeamManagement.ViewModels; // Now fully active!

namespace EsportsTeamManagement.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly ITeamService _teamService;
        private readonly ITournamentService _tournamentService;

        public MatchController(
            IMatchService matchService,
            ITeamService teamService,
            ITournamentService tournamentService)
        {
            _matchService = matchService;
            _teamService = teamService;
            _tournamentService = tournamentService;
        }

        // GET: /Match/Index
        public IActionResult Index()
        {
            var matches = _matchService.GetMatches();
            return View(matches);
        }

        // GET: /Match/Create
        [HttpGet]
        public IActionResult Create()
        {
            var teams = _teamService.GetTeams();
            var tournaments = _tournamentService.GetTournaments();
            //this error 
            var model = new MatchViewModel
            {
                Teams = teams.Select(t => new SelectListItem
                {
                    Value = t.TeamId.ToString(),
                    Text = t.TeamName
                }).ToList(),

                Tournaments = tournaments.Select(t => new SelectListItem
                {
                    Value = t.TournamentId.ToString(),
                    Text = t.TournamentName
                }).ToList(),

                MatchDate = DateTime.Now
            };

            return View(model);
        }

        // POST: /Match/Create
        [HttpPost]
        public IActionResult Create(MatchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Team1Id == model.Team2Id)
            {
                ModelState.AddModelError("", "Team 1 and Team 2 cannot be the same.");
                return View(model);
            }

            MatchDetail match = new MatchDetail
            {
                TournamentId = model.TournamentId,
                Team1Id = model.Team1Id,
                Team2Id = model.Team2Id,
                WinnerTeamId = model.WinnerTeamId,
                MatchDate = model.MatchDate
            };

            _matchService.AddMatch(match);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var match = _matchService.GetMatchById(id);

            if (match == null)
                return NotFound();

            return View(match);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var match = _matchService.GetMatchById(id);

            if (match == null)
                return NotFound();

            var model = new MatchViewModel
            {
                TournamentId = match.TournamentId,
                Team1Id = match.Team1Id,
                Team2Id = match.Team2Id,
                WinnerTeamId = match.WinnerTeamId,
                MatchDate = match.MatchDate ?? DateTime.Now,

                Teams = _teamService.GetTeams().Select(t => new SelectListItem
                {
                    Value = t.TeamId.ToString(),
                    Text = t.TeamName

                }).ToList(),

                // Fetch and map the Tournaments dropdown selection items
                Tournaments = _tournamentService.GetTournaments().Select(t => new SelectListItem
                {
                    Value = t.TournamentId.ToString(),
                    Text = t.TournamentName
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, MatchViewModel model)
        {
            var match = _matchService.GetMatchById(id);

            if (match == null)
                return NotFound();

            match.TournamentId = model.TournamentId;
            match.Team1Id = model.Team1Id;
            match.Team2Id = model.Team2Id;
            match.WinnerTeamId = model.WinnerTeamId;
            match.MatchDate = model.MatchDate;

            _matchService.UpdateMatch(match);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var match = _matchService.GetMatchById(id);

            if (match == null)
                return NotFound();

            return View(match);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _matchService.DeleteMatch(id);

            return RedirectToAction("Index");
        }




    }
}
