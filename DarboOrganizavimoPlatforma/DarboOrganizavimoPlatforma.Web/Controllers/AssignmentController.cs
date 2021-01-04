using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    public class AssignmentController : Controller 
    {

        private readonly IAssignmentService _assingmentService;
        private readonly ITeamService _teamService;
        private readonly UserManager<AppUser> _userManager;

        public AssignmentController(IAssignmentService assingmentService, UserManager<AppUser> userManager, ITeamService teamService)
        {
            _assingmentService = assingmentService;
            _userManager = userManager;
            _teamService = teamService;
        }

        //For Admin - get All assignments. 
        public async Task<IActionResult> GetAllAssignments()
        {
            return View(await _assingmentService.GetAssignments());
        }

        //When team ID is passed. Admin/Manager/TeamLeader/Member. Gets Specific Teams Assignments.
        public async Task<IActionResult> GetTeamAssignmentList(Guid TeamId)
        {
            return View(await _assingmentService.GetTeamAssingments(TeamId));
        }

        ////Gets ALL assignments of Current logged in User.
        //public async Task<IActionResult> GetMemberAssignmentList()
        //{
        //    AppUser user = _userManager.GetUserAsync(User).Result;
        //    Guid id = user.Id;
        //    return View(await _assingmentService.GetUserAssignmentList(id));
        //}

        ////Gets ALL assignments of Current logged in User in a specific Team. 
        //public async Task<IActionResult> GetTeamMemberAssingmentList(Guid TeamId)
        //{
        //    AppUser user = _userManager.GetUserAsync(User).Result;
        //    Guid userId = user.Id;
        //    return View(await _assingmentService.GetUserTeamAssignmentList(userId, TeamId));
        //}

        // GET: Company/Create
        [HttpGet]
        public IActionResult CreateAssignment()
        {
            return View();
        }

        ////POST: Company/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateAssignment(NewAssignmentViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var assingmentId = Guid.NewGuid();
        //        Assignment newAssignment = new Assignment
        //        {
        //            AssignmentName = model.AssignmentName,
        //            AssignmentDescription = model.AssignmentDescription,
        //            CreateTime = DateTime.Now,


        //            // = model.CompanyName,
        //            //CompanyDescription = model.CompanyDescription,
        //            //CreateTime = DateTime.Now,
        //            //CompanyMemberSize = model.CompanyMemberSize,
        //            //CompanyId = companyId,
        //            //AppUsers = new List<AppUser>(),
        //            //CompanyProjects = new List<Project>(),
        //            //Teams = new List<Team>()
        //        };
        //        await _companyService.NewCompany(newCompany);

        //        AppUser newUser = new AppUser()
        //        {
        //            Email = model.Email,
        //            UserName = model.Email,
        //            MemberName = model.MemberName,
        //            JoinDateTime = DateTime.Now,
        //            CompanyId = companyId
        //        };

        //        var result = await _userManager.CreateAsync(newUser, model.ConfirmPassword);
        //        if (result.Succeeded)
        //        {
        //            await _userManager.AddToRoleAsync(newUser, "Manager");
        //            //newCompany.AppUsers.Add(newUser);
        //        }
        //        return RedirectToAction("GetCompanies");
        //    }
        //    return View(model);
        //}


        //Create Assignment -> set name 
        //Rename assignement. 
        //Delete Assignment. 
        //Assign - Select from user list. 
        //List Of Assignment's(Teams Assignments, Member Assigned Assignments) 
        //Change Assignment Status. (mark as done) 
        // add-comment-note?


    }
}
