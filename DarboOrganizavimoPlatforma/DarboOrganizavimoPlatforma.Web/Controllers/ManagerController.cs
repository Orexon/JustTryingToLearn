using DarboOrganizavimoPlatforma.Data;
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
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly Context _context;
        public ManagerController(UserManager<AppUser> userManager, ITeamService teamService, ICompanyService companyService, RoleManager<IdentityRole<Guid>> roleManager, IPasswordHasher<AppUser> passwordHasher, Context context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _teamService = teamService;
            _companyService = companyService;
            _passwordHasher = passwordHasher;
            _context = context;
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

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            //Right now Identical for AdminUser Edit, but planed expandsion for future. 
            AppUser user = await _userManager.FindByIdAsync(id);

            EditUserViewModel model = new EditUserViewModel()
            {
                Email = user.Email,
                MemberName = user.MemberName,
                UserName = user.UserName
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditUser(string id, EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByIdAsync(id);

                user.Email = model.Email;
                user.MemberName = model.MemberName;
                user.UserName = model.UserName;
                if (!string.IsNullOrEmpty(model.Password))
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                }
                await _userManager.UpdateAsync(user);
                return RedirectToAction("CompanyMemberList");
            }
            return View(model);
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            if (id == null)
            {
                return NotFound();  //Add NotFound View. 
            }
            return View(await _userManager.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("CompanyMemberList", "Manager");
        }

        public async Task<IActionResult> CompanyTeamsList()
        {
            AppUser user = _userManager.GetUserAsync(User).Result;
            Guid companyId = user.CompanyId;
            return View(await _teamService.GetCompanyTeams(companyId));
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

        //When selecting A team from a list. 
        //[HttpGet]
        //public async Task<IActionResult> AddTeamMember(Guid teamId)
        //{
        //    ViewBag.AllCompanyUsers = new SelectList(await _teamService.GetListOfAvailableTeamUsers(teamId), "Id", "Email");
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddTeamMember(AddUserToTeamViewModel model, Guid teamId)
        //{
        //    ViewBag.AvailableTeamUsers = new SelectList(await _teamService.GetListOfAvailableTeamUsers(teamId), "Id", "Email");

        //    Team team = await _teamService.GetTeamById(teamId);
        //    AppUser user = await _userManager.FindByIdAsync(model.Id);
        //    //.TeamUsers = user;

        //    //model.Id == UserId + Include.TeamUsers. ?
        //    //
        //    //context.TeamUsers.Where(e => e.Team.TeamId == id).Select(e => e.AppUser).ToListAsync();
        //    //await _context.TeamUsers.Include(x => x.AppUser).Where(x => x.TeamId == id).ToListAsync();   Works But From other side. 

        //    //Employee employee = new Employee();
        //    //Address address = new Address();

        //    //employee.Address = address;
        //    //db.employee.AddObject(employee);
        //    //db.SaveChanges();


        //    // Get Team
        //    // Get User 



        //    // create a new Address
        //    // associate the address with the new employee
        //    // add the employee to the data context
        //    // when you call save changes, since your Address is attached to your
        //    // employee, it will get added for you and you don't have to add it to the
        //    // context yourself. Entity Framework will save the Employee, get the ID
        //    // from this table and then add a new Address record using the ID that was
        //    // just inserted. 


        //    if (ModelState.IsValid)
        //    {
        //        //team.TeamUsers.Add(user);
        //        RedirectToAction("AdminAddUserToCompany");
        //    }
        //    return View(model);         
        //}

        //Manager(CurrentUserCompany, SelectFromCompanyUsers, SelectFromCompanyTeams,ADD) TeamLeader(Select from CompanyUsers, add to Team. Cannot Create TEAMs or browse teams.)
        //Add a member to a team, 2 tables - one with member select, another with current team member list, refreshes the page with the model once added, and shows current teams members

        [HttpPost]
        public async Task<IActionResult> AdminAddUserToCompany(AdminAddUserToCompanyViewModel model)
        {
            ViewBag.AllCompanies = new SelectList(_companyService.GetCompaniesList(), "CompanyId", "CompanyName");
            ViewBag.AllUsers = new SelectList(await _userManager.Users.ToListAsync(), "Id", "Email");

            Company company = await _companyService.GetCompanyById(model.CompanyID);
            AppUser user = await _userManager.FindByIdAsync(model.AppUserID);

            if (ModelState.IsValid)
            {
                if (company.AppUsers.Count >= (int)company.CompanyMemberSize)
                {
                    ViewBag.SizeExceeded = "Company Membership Size Exceeded";
                    return View(model);
                }
                company.AppUsers.Add(user);
                RedirectToAction("AdminAddUserToCompany");
            }
            return View(model);
        }
        //Fix validation For all Creates where such user Email already exists in db UserEmail. 
        //Add Responsibility/Work Roles/PositionRole creation -> Everyone can see it, by it they can decide,if its the right person for adding to a list. eg: Support, ITsupport, GeneralSupport.

    }
}
