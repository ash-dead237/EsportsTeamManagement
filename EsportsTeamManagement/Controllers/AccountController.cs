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
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Account");
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
                HttpContext.Session.SetString(
                    "Username", user.Username);
                HttpContext.Session.SetString(
                    "Role",user.Role.RoleName);

                return RedirectToAction(
                    "Index",
                    "Dashboard");
            }

            ViewBag.Error = "Invalid Credentials";

            return View(model);
        }
    }
}