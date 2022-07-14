using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NixonE.Models;
using NixonE.ViewModels.Acoount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = new AppUser
            {
                FullName = register.FirstName + " " + register.LastName,
                Email = register.Email,
                UserName = register.UserName
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, register.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(appUser, "Admin");

            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == login.Email.ToUpper() && u.IsAdmin);

            if (appUser == null)
            {
                ModelState.AddModelError("", "Email or Password is InCorrect");
                return View(login);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, login.Password, true, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is InCorrect");
                return View(login);
            }

            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> LogOutAsync()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}
