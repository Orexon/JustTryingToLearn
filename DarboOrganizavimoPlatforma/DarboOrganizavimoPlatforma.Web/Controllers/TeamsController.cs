using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DarboOrganizavimoPlatforma.Data;
using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class TeamsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _companyService;
        private readonly ITeamService _teamService;
        
        public TeamsController(ICompanyService companyService, ITeamService teamService, UserManager<AppUser> userManager)
        {
            _companyService = companyService;
            _teamService = teamService;
            _userManager = userManager;
        }

        //For Admin
        public async Task<IActionResult> GetAllTeams()
        {
            return View(await _teamService.GetTeams());
        }

        public IActionResult AdminCreateTeam()
        {
            ViewBag.AllCompanies = new SelectList(_companyService.GetCompaniesList(), "CompanyId", "CompanyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminCreateTeam(AdminNewTeamViewModel model)
        {   
            if (ModelState.IsValid)
            {
                ViewBag.AllCompanies = new SelectList(_companyService.GetCompaniesList(), "CompanyId", "CompanyName");
                Company company = await _companyService.GetCompanyById(model.CompanyID); 

                Team newTeam = new Team
                {
                    TeamName = model.TeamName,
                    TeamDescription = model.TeamDescription,
                    CreateTime = DateTime.Now,
                    Company = company
                    //TeamUsers = new List<TeamUser>()
                };
                await _teamService.NewTeam(newTeam);
                return RedirectToAction("GetAllTeams");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditTeam(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Team team = await _teamService.GetTeamById(id);
            AdminEditTeamViewModel model = new AdminEditTeamViewModel()
            {
                TeamName = team.TeamName,
                TeamDescription = team.TeamDescription
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTeam(Guid id, AdminEditTeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                Team team = await _teamService.GetTeamById(id);
                AppUser currentUser = _userManager.GetUserAsync(User).Result;

                team.TeamName = model.TeamName;
                team.TeamDescription = model.TeamDescription;
                //Team Users List in view with ability to remove or add users to the team. 

                await _teamService.EditTeam(team);
                if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
                {
                    return RedirectToAction("CompanyTeamsList", "Manager");
                }
                return RedirectToAction("GetAllTeams");
            }
            return View(model);
        }

        public async Task<IActionResult> TeamDetails(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Team team = await _teamService.GetTeamById(id);

            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTeam(Guid id)
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            Team team = await _teamService.GetTeamById(id);

            await _teamService.DeleteTeam(team);

            if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
            {
                return RedirectToAction("CompanyTeamsList", "Manager");
            }
            return RedirectToAction("GetAllTeams");
        }

        // "Points" to a team and gives list of TeamMembers.
        public async Task<IActionResult> GetTeamsMemberList(Guid teamId)  
        {
            return View(await _teamService.GetTeamsMemberList(teamId));
        }





        //Adding Users to Team.Cascading Select list.
        //Add 1 user to team as Admin(All Company List +select Company,GetSelectedCompanyTeamList +selectTeam, GetThatComapanyUserList +SelectUser,ADD)  Enable Multiple.
        //------------------------
        //Get Team member List. For everyone. A button -> lets see current team member list.    If TeamLeader = AddMember to team -Select member from company.   
        //Choose a team, get list. For Teamleader
        
    }
}