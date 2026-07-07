using Contract_Monthly_Claim_System.Models.Data;
using Contract_Monthly_Claim_System.Models.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
            ILogger<HomeController> logger,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Lecturer"))
                    return RedirectToAction("Dashboard", "Lecturer");
                else if (User.IsInRole("Coordinator"))
                    return RedirectToAction("Dashboard", "Coordinator");
                else if (User.IsInRole("Manager"))
                    return RedirectToAction("Dashboard", "Manager");
                else if (User.IsInRole("HR")) // Add this line for HR
                    return RedirectToAction("Dashboard", "HR");
            }
            return View();
        }

        // GET: /Home/Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(model);
        }

        // GET: /Home/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index", "Home");
        }

        // Development login (existing)
        [HttpGet]
        [Route("dev-login")]
        public IActionResult DevLogin()
        {
            return View();
        }

        [HttpPost]
        [Route("dev-login")]
        public IActionResult DevLogin(string role)
        {
            return role?.ToLower() switch
            {
                "manager" => RedirectToAction("Dashboard", "Manager"),
                "coordinator" => RedirectToAction("Dashboard", "Coordinator"),
                "lecturer" => RedirectToAction("Dashboard", "Lecturer"),
                "hr" => RedirectToAction("Dashboard", "HR"),
                _ => RedirectToAction("Index", "Home")
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }
    }
}