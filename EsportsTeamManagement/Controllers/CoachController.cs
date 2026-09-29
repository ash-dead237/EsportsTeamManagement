using Microsoft.AspNetCore.Mvc;
using EsportsTeamManagement.Models;

public class CoachController : Controller
{
    private readonly ICoachService _coachService;

    public CoachController(
        ICoachService coachService)
    {
        _coachService = coachService;
    }

    public IActionResult Index()
    {
        var coaches = _coachService.GetCoaches();

        return View(coaches);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(CoachViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        Coach coach = new Coach
        {
            CoachName = model.CoachName,
            ExperienceYears = model.ExperienceYears,
            Email = model.Email
        };

        _coachService.AddCoach(coach);

        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var coach = _coachService.GetCoachById(id);

        if (coach == null)
        {
            return NotFound();
        }

        CoachViewModel model = new CoachViewModel
        {
            CoachName = coach.CoachName,
            ExperienceYears = coach.ExperienceYears??0,
            Email = coach.Email
        };

        return View(model);
    }
    [HttpPost]
    public IActionResult Edit(int id, CoachViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var coach = _coachService.GetCoachById(id);

        if (coach == null)
        {
            return NotFound();
        }

        coach.CoachName = model.CoachName;
        coach.ExperienceYears = model.ExperienceYears;
        coach.Email = model.Email;

        _coachService.UpdateCoach(coach);

        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var coach = _coachService.GetCoachById(id);

        if (coach == null)
        {
            return NotFound();
        }

        return View(coach);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _coachService.DeleteCoach(id);

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Details(int id)
    {
        var coach = _coachService.GetCoachById(id);

        if (coach == null)
        {
            return NotFound();
        }

        return View(coach);
    }




}