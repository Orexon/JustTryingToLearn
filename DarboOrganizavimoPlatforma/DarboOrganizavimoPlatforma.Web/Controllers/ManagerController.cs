using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ITeamService _teamService;
        private readonly ICompanyService _companyService;
        public ManagerController(UserManager<AppUser> userManager, ITeamService teamService, ICompanyService companyService, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _teamService = teamService;
            _companyService = companyService;
        }
        
        public async Task<IActionResult> CompanyTeamsList()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            var companyId = user.CompanyId;
            return View(await _teamService.GetCompanyTeams(companyId));
        }

        public async Task<IActionResult> CompanyMemberList()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid companyId = user.CompanyId;
            List<AppUser> companyUsers = await _companyService.GetCompanyMembersList(companyId);
            var companyUserListViewModel = new List<UserListViewModel>();

            foreach (AppUser companyUser in companyUsers)
            {
                var thisViewModel = new UserListViewModel
                {
                    UserId = companyUser.Id,
                    User = companyUser,
                    Roles = new List<string>(await _userManager.GetRolesAsync(companyUser))
                };
                companyUserListViewModel.Add(thisViewModel);
            }
            return View(companyUserListViewModel);
        }

        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeam(ManagerCreateTeamViewModel model)
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            var companyId = user.CompanyId;

            if (ModelState.IsValid)
            {
                Company company = await _companyService.GetCompanyById(companyId);

                Team newTeam = new Team
                {
                    TeamName = model.TeamName,
                    TeamDescription = model.TeamDescription,
                    CreateTime = DateTime.Now,
                    Company = company
                };
                await _teamService.NewTeam(company, newTeam);
                return RedirectToAction("CompanyTeamList");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            ViewBag.ManagerRoleList = new SelectList(_roleManager.Roles.Where(x => x.Name != "Admin").ToList(), "Name", "Name");

            AppUser user = _userManager.GetUserAsync(User).Result;
            var companyId = user.CompanyId;
            Company company = await _companyService.GetCompanyById(companyId);

            if (company.AppUsers.Count >= (int)company.CompanyMemberSize)
            {
                ViewBag.SizeExceeded = "Company Membership Size Exceeded";
                return RedirectToAction("CompanyMemberList");
            }

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateUser(ManagerCreateUserViewModel model)
        {
            ViewBag.ManagerRoleList = new SelectList(_roleManager.Roles.Where(x => x.Name != "Admin").ToList(), "Name", "Name");

            AppUser user = _userManager.GetUserAsync(User).Result;
            var companyId = user.CompanyId;
            Company company = await _companyService.GetCompanyById(companyId);

            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    MemberName = model.MemberName,
                    JoinDateTime = DateTime.Now,
                    CompanyId = companyId
                };

                var result = await _userManager.CreateAsync(newUser, model.ConfirmPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, model.UserRole);
                    company.AppUsers.Add(newUser);
                    return RedirectToAction("CompanyMemberList");
                }
            }
            return View("~/Views/Manager/CreateUser.cshtml", model);
        }


        //Fix validation For all Creates where such user Email already exists in db UserEmail. 

        //Add a member to a team, 2 tables - one with member select, another with current team member list, refreshes the page with the model once added, and shows current teams members//
    }
}
