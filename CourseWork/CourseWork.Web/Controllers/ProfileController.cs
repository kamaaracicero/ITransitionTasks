using CourseWork.Core.Identity;
using CourseWork.Web.Models.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseWork.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly RoleManager<WebRole> _roleManager;
        private readonly UserManager<WebUser> _userManager;
        private readonly SignInManager<WebUser> _signInManager;

        public ProfileController(RoleManager<WebRole> roleManager,
            UserManager<WebUser> userManager,
            SignInManager<WebUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(new ProfileViewModel(user));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind] LoginViewModel viewModel, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var res = await _signInManager.PasswordSignInAsync(viewModel.UserName,
                    viewModel.Password, viewModel.RememberMe, false);

                if (res.Succeeded)
                {
                    return returnUrl == null || returnUrl == "/"
                        ? RedirectToAction(nameof(Index))
                        : RedirectToAction(returnUrl);
                }

                ModelState.AddModelError("", "Username or password incorrect.");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind] RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new WebUser
                {
                    FirstName = viewModel.FirstName,
                    SecondName = viewModel.SecondName,
                    UserName = viewModel.UserName,
                };

                var res = await _userManager.CreateAsync(user, viewModel.Password);
                if (res.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }


        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogoutUser()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("~/Home/Index");
        }

        [HttpPost]
        public IActionResult DongLogoutUser()
        {
            return LocalRedirect("~/Home/Index");
        }
    }
}
