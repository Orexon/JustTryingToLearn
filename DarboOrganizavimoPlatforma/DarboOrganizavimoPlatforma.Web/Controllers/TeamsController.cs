using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DarboOrganizavimoPlatforma.Data;
using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class TeamsController : Controller
    {
        private readonly Context _context;
        private readonly ICompanyService _companyService;
        private readonly ITeamService _teamService;


        public TeamsController(Context context, ICompanyService companyService, ITeamService teamService)
        {
            _companyService = companyService;
            _context = context;
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _teamService.GetTeams());
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
                };
                await _teamService.NewTeam(company, newTeam);
                return RedirectToAction("Index");
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

                team.TeamName = model.TeamName;
                team.TeamDescription = model.TeamDescription;
                //Team Users List in view with ability to remove or add users to the team. 

                await _teamService.EditTeam(team);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTeam(Guid id)
        {
            Team team = await _teamService.GetTeamById(id);
            await _teamService.DeleteTeam(team);
            return RedirectToAction("Index");
        }
    }
}