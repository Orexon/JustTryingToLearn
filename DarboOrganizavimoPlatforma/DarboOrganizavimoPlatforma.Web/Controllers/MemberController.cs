using DarboOrganizavimoPlatforma.Data;
using DarboOrganizavimoPlatforma.Domains;
using DarboOrganizavimoPlatforma.Services.Interfaces;
using DarboOrganizavimoPlatforma.Web.Models;
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
    public class MemberController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        public MemberController(UserManager<AppUser> userManager,IPasswordHasher<AppUser> passwordHasher, Context context)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _context = context;
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
        public async Task<IActionResult> EditUserProfile(string id,EditUserProfileViewModel model)
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
                AppUser user = await _userManager.FindByIdAsync(userStringId);
                if (!string.IsNullOrEmpty(model.Email))
                {
                    user.Email = model.Email;
                }
                if (!string.IsNullOrEmpty(model.ConfirmPassword))
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, model.ConfirmPassword);
                }
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Profile");
            }
            return View(model);
        }
    }
}
