using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseWork.Core.Identity;
using CourseWork.Web.Models.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<WebRole> _roleManager;
        private readonly UserManager<WebUser> _userManager;

        public RolesController(RoleManager<WebRole> roleManager, UserManager<WebUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index() => View(_roleManager.Roles.ToList());

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult res = await _roleManager.CreateAsync(new WebRole { Name = model.Name });

                if (res.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            WebRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult UserList() => View(_userManager.Users.ToList());

        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            WebUser user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();

                ChangeRoleViewModel viewModel = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    UserRoles = userRoles,
                    AllRoles = allRoles,
                };
                return View(viewModel);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            WebUser user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction(nameof(UserList));
            }

            return NotFound();
        }
    }
}
