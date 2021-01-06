﻿using DarboOrganizavimoPlatforma.Domains;
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
    public class AssignmentController : Controller 
    {
        private readonly IAssignmentService _assignmentService;
        private readonly ITeamService _teamService;
        private readonly ICompanyService _companyService;
        private readonly UserManager<AppUser> _userManager;

        public AssignmentController(IAssignmentService assignmentService, UserManager<AppUser> userManager, ITeamService teamService, ICompanyService companyService)
        {
            _assignmentService = assignmentService;
            _userManager = userManager;
            _teamService = teamService;
            _companyService = companyService;
        }

        //For Admin - get All assignments. 
        public async Task<IActionResult> GetAllAssignments()
        {
            return View(await _assignmentService.GetAssignments());
        }

        //Gets ALL assignments of Current logged in User. // Member Controller part..? 
        public async Task<IActionResult> GetMemberAssignmentList()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid UserId = user.Id;
            return View(await _assignmentService.GetUserAssignmentList(UserId));
        }

        //Gets ALL assignments of Current logged in User in a specific Team. // Member Controller part..? 
        public async Task<IActionResult> GetTeamMemberAssignmentList(Guid TeamId)
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid UserId = user.Id;
            return View(await _assignmentService.GetUserTeamAssignmentList(UserId, TeamId));
        }

        //When team ID is passed. Admin/Manager/TeamLeader/Member. Gets Specific Teams Assignments.
        public async Task<IActionResult> GetTeamAssignmentList(Guid TeamId)
        {
            return View(await _assignmentService.GetTeamAssignments(TeamId));
        }

        // GET: Manager Assignment/Create // Logic mistake.When entering directly - need fix. Select..when should get current team id.
        [HttpGet]
        public async Task<IActionResult> CreateAssignment()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid id = user.CompanyId;
            ViewBag.AllCompanyTeams = new SelectList(await _teamService.GetCompanyTeams(id), "TeamId", "TeamName");
            return View();
        }

        //POST: Manager Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAssignment(NewAssignmentViewModel model)
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid id = user.CompanyId;
            ViewBag.AllCompanyTeams = new SelectList(await _teamService.GetCompanyTeams(id), "TeamId", "TeamName");

            if (ModelState.IsValid)
            {
                Assignment newAssignment = new Assignment
                {
                    AssignmentName = model.AssignmentName,
                    AssignmentDescription = model.AssignmentDescription,
                    CreateTime = DateTime.Now,
                    AssignmentStatus = CompletionStatus.ToDo, // = 0
                    AssignmentTasks = new List<ATask>(),
                    TeamId = model.TeamId,
                    Team = await _teamService.GetTeamById(model.TeamId)
                };
                await _assignmentService.NewAssignment(newAssignment);

                return RedirectToAction("GetTeamAssignmentList", new { model.TeamId });
            }
            return View(model);
        }


        // GET: Manager Assignment Create when Team Is Selected.
        [HttpGet]
        public IActionResult CreateTeamAssignment(Guid TeamId)
        {
            var newTeamAssignmentViewModel = new NewTeamAssignmentViewModel
            {
                CurrentTeamId = TeamId
            };
            return View(newTeamAssignmentViewModel);
        }

        //POST: Manager Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeamAssignment(NewTeamAssignmentViewModel model, Guid TeamId)
        {
            if (ModelState.IsValid)
            {
                Assignment newAssignment = new Assignment
                {
                    AssignmentName = model.AssignmentName,
                    AssignmentDescription = model.AssignmentDescription,
                    CreateTime = DateTime.Now,
                    AssignmentStatus = CompletionStatus.ToDo, // = 0
                    AssignmentTasks = new List<ATask>(),
                    TeamId = TeamId,
                    Team = await _teamService.GetTeamById(TeamId)
                };
                await _assignmentService.NewAssignment(newAssignment);

                return RedirectToAction("GetTeamAssignmentList", new { TeamId });
            }
            return View(model);
        }

        //Edit Assignment //Change State.
        [HttpGet]
        public async Task<IActionResult> EditAssignment(Guid AssignmentId)
        {
            if (AssignmentId == null)
            {
                return NotFound();
            }
            Assignment assignment = await _assignmentService.GetAssignmentById(AssignmentId);

            EditAssignmentViewModel model = new EditAssignmentViewModel()
            {
                TeamId = await _assignmentService.GetTeamByAssignmentId(AssignmentId),
                AssignmentId = assignment.AssignmentId,
                AssignmentName = assignment.AssignmentName,
                AssignmentDescription = assignment.AssignmentDescription,
                AssignmentStatus = assignment.AssignmentStatus
            };
            return View(model);
        }

        //Edit Assignment //Change State.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAssignment(Guid AssignmentId, EditAssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Assignment assignment = await _assignmentService.GetAssignmentById(AssignmentId);
                AppUser currentUser = _userManager.GetUserAsync(User).Result;
                Guid TeamId = await _assignmentService.GetTeamByAssignmentId(AssignmentId);
                
                assignment.AssignmentName = model.AssignmentName;
                assignment.AssignmentDescription = model.AssignmentDescription;
                assignment.AssignmentStatus = model.AssignmentStatus;
                if(model.AssignmentStatus == CompletionStatus.Done)
                {
                    assignment.CompletedTime = DateTime.Now;
                }
                await _assignmentService.EditAssignment(assignment);

                if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
                {
                    return RedirectToAction("GetTeamAssignmentList", "Assignment", new {TeamId });
                }
                return RedirectToAction("GetAllAssignments");
            }
            return View(model);
        }

        //Edit Assignment //Change State.
        public async Task<IActionResult> AssignmentDetails(Guid AssignmentId)
        {
            if (AssignmentId == null)
            {
                return NotFound();
            }
            Assignment assignment = await _assignmentService.GetAssignmentById(AssignmentId);

            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }



        //Delete Assignment
        [HttpPost]
        public async Task<IActionResult> DeleteAssignment(Guid id)
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            Guid TeamId = await _assignmentService.GetTeamByAssignmentId(id);

            Assignment assignment = await _assignmentService.GetAssignmentById(id);

            await _assignmentService.DeleteAssignment(assignment);

            if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
            {
                return RedirectToAction("GetTeamAssignmentList", "Assignment", new { TeamId });
            }
            return RedirectToAction("GetAllAssignments");
        }

        //Add users to assignment.
        [HttpGet]
        public async Task<IActionResult> AssignUsersToAssignment(Guid id, Guid AssignmentId)
        {               
            ViewBag.AvailableTeamUsers = new SelectList(await _assignmentService.GetListOfAvailableAssignmentUsers(id, AssignmentId), "Id", "MemberName");

            List<AppUser> AssignmentMemberList = await _assignmentService.GetAssignmentUserList(AssignmentId);
            //visi assignment members;
            var assignmentMemberListViewModel = new List<UserListViewModel>();
            

            foreach (AppUser member in AssignmentMemberList)
            {
                var thisViewModel = new UserListViewModel
                {
                    UserId = member.Id,
                    User = member,
                    Roles = new List<string>(await _userManager.GetRolesAsync(member))
                };
                assignmentMemberListViewModel.Add(thisViewModel);
            }

            Guid teamId = id;

            var newAssignViewModel = new AssignUsersToAssignmentViewModel
            {
                CurrentTeamId = teamId,
                CurrentAssignmentId = AssignmentId,
                AssignmentMemberListViewModel = assignmentMemberListViewModel
            };

            return View(newAssignViewModel);
        }

        [HttpPost] 
        public async Task<IActionResult> AssignUsersToAssignment(AssignUsersToAssignmentViewModel newAssignViewModel, Guid id, Guid AssignmentId)
        {
            ViewBag.AvailableTeamUsers = new SelectList(await _assignmentService.GetListOfAvailableAssignmentUsers(id, AssignmentId), "Id", "MemberName");

            if (ModelState.IsValid)
            {
                Guid guidid = Guid.Parse(newAssignViewModel.AppUserId);

                UserAssignment userAssignment = new UserAssignment
                {
                    AppUser = await _userManager.FindByIdAsync(newAssignViewModel.AppUserId),
                    AppUserId = guidid,
                    Assignment = await _assignmentService.GetAssignmentById(AssignmentId),
                    AssignmentId = AssignmentId
                };
                await _assignmentService.AddUserAssignment(userAssignment);

                List<AppUser> AssignmentMemberList = await _assignmentService.GetAssignmentUserList(AssignmentId);
                if (AssignmentMemberList.Count > 0)
                {
                    await _assignmentService.ChangeStatusToInProgress(AssignmentId);
                }
                return RedirectToAction("AssignUsersToAssignment", new { AssignmentId });
            }
            return View(newAssignViewModel);
        }

        //Remove User from an assignment.
        [HttpGet]
        public async Task<IActionResult> RemoveUserFromAssignment(Guid AssignmentId, string id, Guid TeamId)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            Assignment assignment = await _assignmentService.GetAssignmentById(AssignmentId);
            await _assignmentService.RemoveUserAssignment(AssignmentId, assignment, id, appUser);
            return RedirectToAction("AssignUsersToAssignment", "Assignment", new {@id = TeamId, AssignmentId });
        }
    }
}
