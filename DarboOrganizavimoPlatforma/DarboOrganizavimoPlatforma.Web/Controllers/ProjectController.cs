using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ITeamService _teamService;
        private readonly ICompanyService _companyService;
        private readonly IProjectService _projectService;

        public ProjectController(UserManager<AppUser> userManager, ITeamService teamService, ICompanyService companyService, RoleManager<IdentityRole<Guid>> roleManager, IProjectService projectService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _teamService = teamService;
            _companyService = companyService;
            _projectService = projectService;
        }

        public async Task<IActionResult> GetAllProjects()
        {
            return View(await _projectService.GetProjects());
        }

        public IActionResult AdminCreateProject()
        {
            ViewBag.AllCompanies = new SelectList(_companyService.GetCompaniesList(), "CompanyId", "CompanyName");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminCreateProject(AdminNewProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.AllCompanies = new SelectList(_companyService.GetCompaniesList(), "CompanyId", "CompanyName");
                Company company = await _companyService.GetCompanyById(model.CompanyID);

                var projectId = Guid.NewGuid();
                Project newProject = new Project
                {
                    ProjectId = projectId,
                    ProjectName = model.ProjectName,
                    ProjectDescription = model.ProjectDescription,
                    CreateTime = DateTime.Now,
                    Company = company
                };

               // await _projectService.NewProject(company, newProject);

                return RedirectToAction("GetAllTeams");
            }
            return View(model);
        }


    }
}
