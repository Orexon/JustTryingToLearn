using DarboOrganizavimoPlatforma.Data;
using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    [Authorize(Roles = "Admin,Manager,Member")]
    public class MemberController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly ICompanyService _companyService;
        private readonly ITeamService _teamService;
        private readonly IAssignmentService _assignmentService;
        private readonly ITaskService _taskService;
        public MemberController(UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher, Context context, ICompanyService companyService, ITeamService teamService, IAssignmentService assignmentService, ITaskService taskService)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _context = context;
            _companyService = companyService;
            _teamService = teamService;
            _assignmentService = assignmentService;
            _taskService = taskService;
        }

        public async Task<IActionResult> Profile()
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            Guid userGuidId = currentUser.Id;
            AppUser user = await _context.Users.Where(x => x.Id == userGuidId).Include(x => x.Company).FirstOrDefaultAsync();
            return View(user);
        }

        [HttpGet]
        public IActionResult EditUserProfile()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid userGuidId = user.Id;
            string userStringId = userGuidId.ToString();

            EditUserProfileViewModel model = new EditUserProfileViewModel()
            {
                UserId = userStringId,
                MemberName = user.MemberName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Location = user.Location,
                Position = user.Position,
                Notes = user.Notes
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserProfileViewModel model)
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            Guid userGuidId = currentUser.Id;
            string userStringId = userGuidId.ToString();
            AppUser user = await _userManager.FindByIdAsync(userStringId);

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.MemberName))
                {
                    user.MemberName = model.MemberName;
                }
                if (!string.IsNullOrEmpty(model.UserName))
                {
                    user.UserName = model.UserName;
                }
                if (!string.IsNullOrEmpty(model.FirstName))
                {
                    user.FirstName = model.FirstName;
                }
                if (!string.IsNullOrEmpty(model.LastName))
                {
                    user.LastName = model.LastName;
                }
                if (!string.IsNullOrEmpty(model.Location))
                {
                    user.Location = model.Location;
                }
                if (!string.IsNullOrEmpty(model.Position))
                {
                    user.Position = model.Position;
                }
                if (!string.IsNullOrEmpty(model.Notes))
                {
                    user.Notes = model.Notes;
                }
                if (!string.IsNullOrEmpty(model.PhoneNumber))
                {
                    user.PhoneNumber = model.PhoneNumber;
                }
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    MemoryStream dataStream = new MemoryStream();
                    await file.CopyToAsync(dataStream);
                    user.ProfilePicture = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Profile", "Member");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePasswordAndEmail()
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            Guid userGuidId = currentUser.Id;
            string userStringId = userGuidId.ToString();

            ChangePassAndEmailViewModel model = new ChangePassAndEmailViewModel()
            {
                UserId = userStringId,
                Email = currentUser.Email
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> ChangePasswordAndEmail(ChangePassAndEmailViewModel model)
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            Guid userGuidId = currentUser.Id;
            string userStringId = userGuidId.ToString();

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.Email))
                {
                    currentUser.Email = model.Email;
                }
                if (!string.IsNullOrEmpty(model.currentPassword))
                {
                    if (!string.IsNullOrEmpty(model.ConfirmPassword))
                    {
                        var result = await _userManager.ChangePasswordAsync(currentUser, model.currentPassword, model.ConfirmPassword);
                        if (result.Succeeded)
                        {
                            currentUser.PasswordHash = _passwordHasher.HashPassword(currentUser, model.ConfirmPassword);
                            await _userManager.UpdateAsync(currentUser);
                            return RedirectToAction("Profile");
                        }
                    } 
                }
            }
            return View(model);
        }

        // Member Company Details view. Simple available(less) details.
        public async Task<IActionResult> MemberCompanyDetails()
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            Guid companyId = currentUser.CompanyId;

            Company company = await _companyService.GetCompanyById(companyId);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        public async Task<IActionResult> GetMemberTeams()
        {
            AppUser currentUser = _userManager.GetUserAsync(User).Result;
            Guid userId = currentUser.Id;

            List<Team> memberTeams = await _teamService.GetMemberTeamsByUserId(userId);

            return View(memberTeams);
        }

        //Specific Team members of a logged in User Specific team.
        public async Task<IActionResult> GetTeamsMemberList(Guid id)
        {
            List<AppUser> TeamsMemberList = await _teamService.GetTeamsMemberList(id);
            var teamUserListViewModel = new List<UserListViewModel>();

            foreach (AppUser member in TeamsMemberList)
            {
                var thisViewModel = new UserListViewModel
                {
                    UserId = member.Id,
                    User = member,
                    Roles = new List<string>(await _userManager.GetRolesAsync(member))
                };
                teamUserListViewModel.Add(thisViewModel);
            }
            return View(teamUserListViewModel);
        }

        //Gets ALL assignments of Current logged in User in a specific Team. // Member Controller
        public async Task<IActionResult> GetTeamMemberAssignmentList(Guid TeamId)
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid UserId = user.Id;
            return View(await _assignmentService.GetUserTeamAssignmentList(UserId, TeamId));
        }

        public async Task<IActionResult> MemberTeamDetails(Guid id)
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

        public async Task<IActionResult> UserDetails(string id)
        {
            if (id == null)
            {
                return NotFound();  //Add NotFound View. 
            }
            return View(await _userManager.FindByIdAsync(id));
        }

        //Gets ALL assignments of Current logged in User. // Member Controller
        public async Task<IActionResult> GetMemberAssignmentList()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid UserId = user.Id;
            return View(await _assignmentService.GetUserAssignmentList(UserId));
        }

        //Get All member tasks && all member Written tasks
        public async Task<IActionResult> GetMemberAssignmentsTasks()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;

            var taskViewModel = new UserTaskViewModel
            {
                UserTasks = await _taskService.GetUserAssignmentTaskList(user.Id),
                UserWrittenTasks = await _taskService.GetUseWrittenTaskList(user.Id)
            };

            return View(taskViewModel);
        }
    }
}
