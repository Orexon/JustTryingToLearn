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
    public class AssignmentController : Controller 
    {
        private readonly IAssignmentService _assingmentService;
        private readonly ITeamService _teamService;
        private readonly ICompanyService _companyService;
        private readonly UserManager<AppUser> _userManager;

        public AssignmentController(IAssignmentService assingmentService, UserManager<AppUser> userManager, ITeamService teamService, ICompanyService companyService)
        {
            _assingmentService = assingmentService;
            _userManager = userManager;
            _teamService = teamService;
            _companyService = companyService;
        }

        //For Admin - get All assignments. 
        public async Task<IActionResult> GetAllAssignments()
        {
            return View(await _assingmentService.GetAssignments());
        }

        //Gets ALL assignments of Current logged in User. // Member Controller part..? 
        public async Task<IActionResult> GetMemberAssignmentList()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid UserId = user.Id;
            return View(await _assingmentService.GetUserAssignmentList(UserId));
        }

        //Gets ALL assignments of Current logged in User in a specific Team. // Member Controller part..? 
        public async Task<IActionResult> GetTeamMemberAssingmentList(Guid TeamId)
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid UserId = user.Id;
            return View(await _assingmentService.GetUserTeamAssignmentList(UserId, TeamId));
        }

        //When team ID is passed. Admin/Manager/TeamLeader/Member. Gets Specific Teams Assignments.
        public async Task<IActionResult> GetTeamAssignmentList(Guid TeamId)
        {
            return View(await _assingmentService.GetTeamAssingments(TeamId));
        }

        // GET: Manager Assingment/Create // Logic mistake.When entering directly - need fix. Select..when should get current team id.
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
                    AssingmentStatus = CompletionStatus.ToDo, // = 0
                    AssingmentTasks = new List<ATask>(),
                    TeamId = model.TeamId,
                    Team = await _teamService.GetTeamById(model.TeamId)
                };
                await _assingmentService.NewAssignment(newAssignment);

                return RedirectToAction("GetTeamAssignmentList", new { model.TeamId });
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
            Assignment assignment = await _assingmentService.GetAssignmentById(AssignmentId);

            EditAssignmentViewModel model = new EditAssignmentViewModel()
            {
                AssignmentName = assignment.AssignmentName,
                AssignmentDescription = assignment.AssignmentDescription,
                AssingmentStatus = assignment.AssingmentStatus
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
                Assignment assignment = await _assingmentService.GetAssignmentById(AssignmentId);
                AppUser currentUser = _userManager.GetUserAsync(User).Result;
                Guid TeamId = await _assingmentService.GetTeamByAssingmentId(AssignmentId);
                
                assignment.AssignmentName = model.AssignmentName;
                assignment.AssignmentDescription = model.AssignmentDescription;
                assignment.AssingmentStatus = model.AssingmentStatus;
                if(model.AssingmentStatus == CompletionStatus.Done)
                {
                    assignment.CompletedTime = DateTime.Now;
                }
                await _assingmentService.EditAssignment(assignment);

                if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
                {
                    return RedirectToAction("GetTeamAssingments", "Assigment", new {TeamId });
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
            Assignment assignment = await _assingmentService.GetAssignmentById(AssignmentId);

            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        //Delete Assignments
        [HttpPost]
        public async Task<IActionResult> DeleteAssignment(Guid AssignmentId)
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            Guid TeamId = await _assingmentService.GetTeamByAssingmentId(AssignmentId);

            Assignment assignment = await _assingmentService.GetAssignmentById(AssignmentId);

            await _assingmentService.DeleteAssignment(assignment);

            if (await _userManager.IsInRoleAsync(currentUser, "Manager"))
            {
                return RedirectToAction("GetTeamAssingments", "Assigment", new { TeamId });
            }
            return RedirectToAction("GetAllAssignments");
        }

        //Add users to assignment.
        [HttpGet]
        public async Task<IActionResult> AssignUsersToAssignment(Guid id, Guid assignmentId)
        {               
            ViewBag.AvailableTeamUsers = new SelectList(await _assingmentService.GetListOfAvailableAssignmentUsers(id, assignmentId), "Id", "MemberName");

            List<AppUser> AssingmentMemberList = await _assingmentService.GetAssignmentUserList(assignmentId);
            //visi assignment members;
            var assignmentMemberListViewModel = new List<UserListViewModel>();
            

            foreach (AppUser member in AssingmentMemberList)
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

            var newviewmodel = new AssignUsersToAssignmentViewModel
            {
                TeamId = teamId,
                AssignmentId = assignmentId,
                AssignmentMemberListViewModel = assignmentMemberListViewModel
            };

            return View(newviewmodel);
        }

        //Add users to assignment. Get
        [HttpPost] 
        public async Task<IActionResult> AssignUsersToAssignment(AssignUsersToAssignmentViewModel model, Guid id, Guid assignmentId)
        {
            ViewBag.AvailableTeamUsers = new SelectList(await _assingmentService.GetListOfAvailableAssignmentUsers(id, assignmentId), "Id", "MemberName");

            if (ModelState.IsValid)
            {
                Guid guidid = Guid.Parse(model.AppUserId);

                UserAssingment userAssingment = new UserAssingment
                {
                    AppUser = await _userManager.FindByIdAsync(model.AppUserId),
                    AppUserId = guidid,
                    Assignment = await _assingmentService.GetAssignmentById(assignmentId),
                    AssingmentId = assignmentId
                };
                await _assingmentService.AddUserAssignment(userAssingment);

                List<AppUser> AssingmentMemberList = await _assingmentService.GetAssignmentUserList(assignmentId);
                if (AssingmentMemberList.Count > 0)
                {
                    await _assingmentService.ChangeStatusToInProgress(assignmentId);
                }
                return RedirectToAction("AssignUsersToAssingment");
            }
            return View(model);
        }

        //Remove User from an assignment.
        [HttpGet]
        public async Task<IActionResult> RemoveUserFromAssignment(Guid AssignmentId, string id, Guid TeamId)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            Assignment assignment = await _assingmentService.GetAssignmentById(AssignmentId);
            await _assingmentService.RemoveUserAssignment(AssignmentId, assignment, id, appUser);
            return RedirectToAction("AssignUsersToAssingment", "Assignment", new { TeamId });
        }
    }
}
