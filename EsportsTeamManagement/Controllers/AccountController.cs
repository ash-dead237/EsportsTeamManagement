using Microsoft.AspNetCore.Mvc;
using EsportsTeamManagement.Services;
using EsportsTeamManagement.ViewModels;

namespace EsportsTeamManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userService.ValidateUser(
                model.Username,
                model.Password);

            if (user != null)
            {
                return RedirectToAction(
                    "Index",
                    "Dashboard");
            }

            ViewBag.Error = "Invalid Credentials";

            return View(model);
        }
    }
}