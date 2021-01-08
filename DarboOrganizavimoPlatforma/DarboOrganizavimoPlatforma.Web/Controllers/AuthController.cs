using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarboOrganizavimoPlatforma.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AuthController(SignInManager<AppUser> signInManager,RoleManager<IdentityRole<Guid>> roleManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        
        public IActionResult Login(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AuthError = "Invalid login data";
                return View("~/Views/Auth/Login.cshtml", model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {   
                if(!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.AuthError = "Invalid login data";
            return View("~/Views/Auth/Login.cshtml", model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}
