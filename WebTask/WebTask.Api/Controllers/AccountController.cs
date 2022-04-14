using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTask.Api.Core;
using WebTask.Api.Models.Account;

namespace WebTask.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<WebUser> _signInManager;
        private readonly UserManager<WebUser> _userManager;

        public AccountController(SignInManager<WebUser> signInManager,
            UserManager<WebUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register([Bind] RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new WebUser
                {
                    UserName = viewModel.Username,
                    Email = viewModel.Email,
                    RegistrationDate = System.DateTime.Now,
                    LastLoginDate = System.DateTime.Now,
                };

                var res = await _userManager.CreateAsync(user, viewModel.Password);
                if (res.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return LocalRedirect("~/Home/Index");
                }

                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login([Bind] LoginViewModel viewModel,
            string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var identityRes = await _signInManager.PasswordSignInAsync(viewModel.Username,
                    viewModel.Password,
                    viewModel.RememberMe,
                    false);
                if (identityRes.IsLockedOut)
                {
                    return RedirectToAction(nameof(Banned));
                }

                if (identityRes.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(viewModel.Username);
                    user.LastLoginDate = System.DateTime.Now;
                    await _userManager.UpdateAsync(user);

                    return returnUrl == null || returnUrl == "/"
                        ? LocalRedirect("~/Home/Index")
                        : RedirectToAction(returnUrl);
                }

                ModelState.AddModelError("", "Username or password incorrect.");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Logout() => View();

        [HttpPost]
        public async Task<IActionResult> LogoutUser()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("~/Home/Index");
        }

        [HttpPost]
        public IActionResult DontLogoutUser()
        {
            return LocalRedirect("~/Home/Index");
        }

        [HttpGet]
        public IActionResult Banned()
        {
            return View();
        }
    }
}
