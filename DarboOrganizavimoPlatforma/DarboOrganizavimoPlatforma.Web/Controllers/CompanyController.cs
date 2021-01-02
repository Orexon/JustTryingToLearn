using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Identity;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using System.Collections.Generic;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _companyService;

        public CompanyController(UserManager<AppUser> userManager,ICompanyService companyService)
        {
            _userManager = userManager;
            _companyService = companyService;
        }

        // GET: Company
        public async Task<IActionResult> GetCompanies()
        {      
            return View(await _companyService.GetCompanies());
        }

        // GET: Company/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Company company = await _companyService.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // GET: Company/Create
        [HttpGet]
        public IActionResult CreateCompany()
        {
            return View();
        }

        //POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCompany(NewCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var companyId = Guid.NewGuid();
                Company newCompany = new Company
                {
                    CompanyName = model.CompanyName,
                    CompanyDescription = model.CompanyDescription,
                    CreateTime = DateTime.Now,
                    CompanyMemberSize = model.CompanyMemberSize,
                    CompanyId = companyId,
                    AppUsers = new List<AppUser>()
                 };
                await _companyService.NewCompany(newCompany);

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
                    await _userManager.AddToRoleAsync(newUser, "Manager");
                    //newCompany.AppUsers.Add(newUser);
                }
                return RedirectToAction("GetCompanies");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditCompany(Guid id)
        {
            Company company = await _companyService.GetCompanyById(id);
            AdminEditCompanyViewModel model = new AdminEditCompanyViewModel()
            {
                CompanyName = company.CompanyName,
                CompanyDescription = company.CompanyDescription,
                CompanyMemberSize = company.CompanyMemberSize
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCompany(Guid id, AdminEditCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Company company = await _companyService.GetCompanyById(id);

                company.CompanyName = model.CompanyName;
                company.CompanyDescription = model.CompanyDescription;
                company.CompanyMemberSize = model.CompanyMemberSize;

                await _companyService.EditCompany(company);
                return RedirectToAction("GetCompanies");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            Company company = await _companyService.GetCompanyById(id);
            await _companyService.DeleteCompany(company);
            return RedirectToAction("GetUserList", "Admin");
        }
    }
}

