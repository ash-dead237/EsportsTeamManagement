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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    "Role", user.Role.RoleName);

                return RedirectToAction(
                    "Index",
                    "Dashboard");
            }
            //viewBag vs viewdata
            //viewdata is a dictionary object that allows you to pass data from the controller to the view using key-value pairs.
            //It is useful for passsing small ammount of data.
            //viewbag is a dynamic object.


            ViewBag.Error = "Invalid Credentials";

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = _userService.RegisterUser(
                model.Username.Trim(),
                model.Email.Trim(),
                model.Password);

            switch (result)
            {
                case UserRegistrationResult.Success:
                    TempData["Success"] = "Your Viewer account was created. Please log in.";
                    return RedirectToAction(nameof(Login));
                case UserRegistrationResult.UsernameAlreadyExists:
                    ModelState.AddModelError(nameof(model.Username), "That username is already taken.");
                    break;
                case UserRegistrationResult.ViewerRoleNotConfigured:
                    ModelState.AddModelError(string.Empty, "Registration is unavailable because the Viewer role is not configured.");
                    break;
            }

            return View(model);
        }
    }
}