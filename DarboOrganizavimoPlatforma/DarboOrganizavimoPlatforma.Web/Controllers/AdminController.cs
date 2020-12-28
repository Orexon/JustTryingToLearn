using DarboOrganizavimoPlatforma.Data;
using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
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
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly Context _context;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly ICompanyService _companyService;

        public AdminController(UserManager<AppUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, Context context, IPasswordHasher<AppUser> passwordHasher, ICompanyService companyService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
            _passwordHasher = passwordHasher;
            _companyService =  companyService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetUserList()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();

            foreach (AppUser user in users)
            {
                var thisViewModel = new UserRolesViewModel
                {
                    UserId = user.Id,
                    User = user,
                    Roles = await GetUserRoles(user)
                };
                userRolesViewModel.Add(thisViewModel);
            }
            return View(userRolesViewModel);
        }
        
        public async Task<List<string>> GetUserRoles(AppUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        [HttpGet]
        public IActionResult NewUser()
        {
            ViewBag.allRoles = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
            
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> NewUser(NewUserViewModel model)
        {
            ViewBag.allRoles = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");

            if (ModelState.IsValid)
            {               
                AppUser newUser = new AppUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    MemberName = model.MemberName,
                    JoinDateTime = DateTime.Now
                };

                var result = await _userManager.CreateAsync(newUser, model.ConfirmPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, model.UserRole);
                    
                    return RedirectToAction("GetUserList");
                }
            }
            return View("~/Views/Admin/NewUser.cshtml", model);
        }
     

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            AdminEditUserViewModel model = new AdminEditUserViewModel()
            {
                Email = user.Email,
                MemberName = user.MemberName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditUser(string id ,AdminEditUserViewModel model) 
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByIdAsync(id);

                user.Email = model.Email;
                user.MemberName = model.MemberName;
                user.UserName = model.UserName;
                user.PhoneNumber = model.PhoneNumber;
                if (!string.IsNullOrEmpty(model.Password))
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                }
                await _userManager.UpdateAsync(user);
                return RedirectToAction("GetUserList");
            }
            return View(model);
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _userManager.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("GetUserList", "Admin");
        }

        //add user to a company : find conpany by id. If company user list is < than company plan enum add member, else error msg. 
        //Errors
        [HttpGet]
        public async Task<IActionResult> AdminAddUserToCompany()
        {
            ViewBag.AllCompanies = new SelectList(_companyService.GetCompaniesList(), "CompanyId", "CompanyName");
            ViewBag.AllUsers =  new SelectList(await _userManager.Users.ToListAsync(), "Id", "Email");
            return View();
        }

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


        //+ Admin - Remove User from company - Delete User + 
        //  Admin - Remove multiple User from company. 

        //+ Admin - Add User to Company. HOW -> Get Company List, select company, Get User list, Select User. Add to Company User list. If not over member size.
        // Admin - Add Multiple User to company. Check if not over member size. Foreach selected add to company.. checkbox'es per post. 

        //+ Admin - Remove Teams. Remove specific companies team/teams. 
        // Admin - Remove Projects. Remove specific companies Project/Projects.

        //Manager - Create User - add user to company member list if not over member size.
        //Manager - Create Teams. 
        //Manager - Add/Remove TeamLeaders from Teams.
        //Manager - Get All Company Members List.  // where(x => x.id == CompanyID)
        //Manager - Get Company Project List. InOtherWords = List of all projects that a company has created. 
        //Manager - Get Company Project Teams List. IOW = Teams working on a specific project /&or/ list of Teams company Has created.
        //Manager - Get Company Project Teams Members List. IOW = Members working in a specific Team /&or/ on a specific project.

        //TeamLeader - Add/Remove members to Teams.
        //TeamLeader side - GetProject list. IOW = List of project the current Member is currently assigned to.
        //TeamLeader side - GetProject list. IOW = List of project the current Member is currently assigned to.

        //Member side - Get Project list . IOW = List of project the current Member is currently assigned to.
        //Member side - Get list of teams. IOW = List of Teams member is assingned to. 

        //Tasks Controller - Create task(description,time,id)
        //Task

        //Project controller

        //Icons for Delete/Edit/Info.
        //Validation for NewTeam
        //Correct Delete Behaviour


    }
}
