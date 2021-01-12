using DarboOrganizavimoPlatforma.Data;
using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    [Authorize(Roles = "Admin")]
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
            var users = await _userManager.Users.Include(x=>x.Company).ToListAsync();
            var userListViewModel = new List<UserListViewModel>();

            foreach (AppUser user in users)
            {
                var thisViewModel = new UserListViewModel
                {
                    UserId = user.Id,
                    User = user,
                    Roles = await GetUserRoles(user)
                };
                userListViewModel.Add(thisViewModel);
            }
            return View(userListViewModel);
        }
        
        public async Task<List<string>> GetUserRoles(AppUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            ViewBag.allRoles = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
            ViewBag.AllCompanies = new SelectList(_companyService.GetCompaniesList(), "CompanyId", "CompanyName");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateUser(NewUserViewModel model)
        {
            ViewBag.AllCompanies = new SelectList(_companyService.GetCompaniesList(), "CompanyId", "CompanyName");
            ViewBag.allRoles = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");

            if (ModelState.IsValid)
            {               
                AppUser newUser = new AppUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    MemberName = model.MemberName,
                    JoinDateTime = DateTime.Now,
                    CompanyId = model.CompanyID
                };

                var result = await _userManager.CreateAsync(newUser, model.ConfirmPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, model.UserRole);
                    Company company = await _companyService.GetCompanyById(model.CompanyID);
                    if (company.AppUsers.Count >= (int)company.CompanyMemberSize)
                    {
                        ViewBag.SizeExceeded = "Company Membership Size Exceeded";
                        return View(model);
                    }
                    company.AppUsers.Add(newUser);
                    return RedirectToAction("GetUserList");
                }
            }
            return View("~/Views/Admin/CreateUser.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            EditUserViewModel model = new EditUserViewModel()
            {
                Email = user.Email,
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
        public async Task<IActionResult> EditUser(string id ,EditUserViewModel model) 
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByIdAsync(id);

                user.Email = model.Email;
                user.MemberName = model.MemberName;
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Location = model.Location;
                user.Position = model.Position;
                user.Notes = model.Notes;
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

    }
}
