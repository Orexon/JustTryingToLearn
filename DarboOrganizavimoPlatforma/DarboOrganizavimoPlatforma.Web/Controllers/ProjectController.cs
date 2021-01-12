using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
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
                await _projectService.NewProject(newProject);
                return RedirectToAction("GetAllProjects");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditProject(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Project project = await _projectService.GetProjectById(id);
            EditProjectViewModel model = new EditProjectViewModel()
            {
                ProjectName = project.ProjectName,
                ProjectDescription = project.ProjectDescription
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProject(Guid id, EditProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                Project project = await _projectService.GetProjectById(id);
                AppUser currentUser = _userManager.GetUserAsync(User).Result;

                project.ProjectName = model.ProjectName;
                project.ProjectDescription = model.ProjectDescription;
                //Team Users List in view with ability to remove or add users to the team. 

                await _projectService.EditProject(project);
                if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
                {
                    return RedirectToAction("CompanyProjectList", "Manager");
                }
                return RedirectToAction("GetAllProjects");
            }
            return View(model);
        }

        public async Task<IActionResult> ProjectDetails(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Project project = await _projectService.GetProjectById(id);

            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            Project project = await _projectService.GetProjectById(id);

            await _projectService.DeleteProject(project);

            if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
            {
                return RedirectToAction("CompanyProjectList", "Manager");
            }
            return RedirectToAction("GetAllProjects");
        }

    }
}
