using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{   
    //[Authorize(Roles = "Admin,Manager")]
    public class ManagerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITeamService _teamService;
        private readonly ICompanyService _companyService;
        public ManagerController(UserManager<AppUser> userManager, ITeamService teamService, ICompanyService companyService)
        {
            _userManager = userManager;
            _teamService = teamService;
            _companyService = companyService;
        }
        
        public async Task<IActionResult> CompanyTeamsList()
        {
            //var currentUserid =  _userManager.GetUserAsync(User).Result.Id;   // .Result.Company;

            //var companyId = await _userManager.Users.Include(x => x.Company).Where(x => x.Company.CompanyId == currentUserid).FirstOrDefaultAsync();
            // var user1 = await _userManager.Users.Include(x => x.Company).SingleAsync(x => x.NormalizedEmail == email);

            AppUser user = _userManager.GetUserAsync(User).Result;
            var companyId = user.CompanyId;
           
            return View(await _teamService.GetCompanyTeams(companyId));

            // Get Current Users(managers) Company Teams list. 
        }

        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeam(ManagerNewTeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                Company company =  _userManager.GetUserAsync(User).Result.Company;

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




        //Add a member to a team, 2 tables - one with member select, another with current team member list, refreshes the page with the model once added, and shows current teams members//
    }
}
