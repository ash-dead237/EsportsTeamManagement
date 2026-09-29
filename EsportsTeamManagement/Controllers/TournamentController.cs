using Microsoft.AspNetCore.Mvc;
using EsportsTeamManagement.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class TournamentController : Controller
{
    private readonly ITournamentService _tournamentService;

    public TournamentController(
        ITournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }

    public IActionResult Index()
    {
        var tournaments =
            _tournamentService.GetTournaments();

        return View(tournaments);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(TournamentViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        Tournament tournament = new Tournament
        {
            TournamentName = model.TournamentName,
            Location = model.Location,
            PrizePool = model.PrizePool,
            StartDate = model.StartDate,
            EndDate = model.EndDate
        };

        _tournamentService.AddTournament(tournament);

        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var tournament = _tournamentService.GetTournamentById(id);

        if (tournament == null)
        {
            return NotFound();
        }

        TournamentViewModel model = new TournamentViewModel
        {
            TournamentName = tournament.TournamentName,
            Location = tournament.Location,
            PrizePool = tournament.PrizePool??0,
            StartDate = tournament.StartDate??DateOnly.FromDateTime(DateTime.Now),
            EndDate = tournament.EndDate??DateOnly.FromDateTime(DateTime.Now)
        };

        return View(model);
    }
    [HttpPost]
    public IActionResult Edit(int id, TournamentViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var tournament = _tournamentService.GetTournamentById(id);

        if (tournament == null)
        {
            return NotFound();
        }

        tournament.TournamentName = model.TournamentName;
        tournament.Location = model.Location;
        tournament.PrizePool = model.PrizePool;
        tournament.StartDate = model.StartDate;
        tournament.EndDate = model.EndDate;

        _tournamentService.UpdateTournament(tournament);

        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var tournament = _tournamentService
            .GetTournamentById(id);

        if (tournament == null)
        {
            return NotFound();
        }

        return View(tournament);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _tournamentService.DeleteTournament(id);

        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Details(int id)
    {
        var tournament = _tournamentService
            .GetTournamentById(id);

        if (tournament == null)
        {
            return NotFound();
        }

        return View(tournament);
    }





}