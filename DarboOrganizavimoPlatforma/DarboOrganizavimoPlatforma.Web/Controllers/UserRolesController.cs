using DarboOrganizavimoPlatforma.Data;
using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ICompanyService _companyService;

        public UserRolesController(UserManager<AppUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, ICompanyService companyService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesViewModel>();

            AppUser currentUser = _userManager.GetUserAsync(User).Result;

            IEnumerable<IdentityRole<Guid>> roleList = null;

            if(await _userManager.IsInRoleAsync(currentUser, "Admin"))
            {
                roleList = _roleManager.Roles;
            }
            else if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
            {
                roleList = _roleManager.Roles.Where(x => x.Name != "Admin").ToList();
            }
            foreach (var role in roleList)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);           
        }
        [HttpPost] //return paths if error. Change/Optimize.
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            Guid companyId = currentUser.CompanyId;
            var managerList = await _userManager.GetUsersInRoleAsync("Manager");
            int count = managerList.Where(x => x.CompanyId == companyId).ToList().Count();

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);

            //If the current user is Admin & if Admin selects himself and if admin wants to remove admin role from himself - restrict removal. 
            if (await _userManager.IsInRoleAsync(currentUser, "Admin") && user == currentUser && roles.Contains("Admin"))
            {
                ModelState.AddModelError("", "Cannot remove Admin Role from admin. Admins are forever!");
                return View(model);
            }
            //If the current user is Manager & if manager selects himself and if Manager wants to remove manager role from the last manager of a company - restrict removal. 
            else if (await _userManager.IsInRoleAsync(currentUser, "Manager") && user == currentUser && count < 2)
            {
                ModelState.AddModelError("", "Cannot remove Manager role from the last existing Manager in a Company");
                return View(model);
            }
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }         

            if (await _userManager.IsInRoleAsync(currentUser, "Admin"))
            {
                return RedirectToAction("GetUserList", "Admin");
            }
            return RedirectToAction("CompanyMemberList", "Manager");
        }
    }
}