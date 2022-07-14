using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NixonE.DAL;
using NixonE.Models;
using NixonE.ViewModels.Acoount;
using NixonE.ViewModels.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly NixonDbContext _context;
        public AccountController(RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,NixonDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
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
                UserName = register.UserName,
                IsAdmin = false
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

            await _userManager.AddToRoleAsync(appUser,"Member");

            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index","Home");
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

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u=>u.NormalizedEmail == login.Email.ToUpper() && !u.IsAdmin);

            if(appUser == null)
            {
                ModelState.AddModelError("", "Email or Password is InCorrect");
                return View(login);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, login.Password,true,true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is InCorrect");
                return View(login);
            }

            string cookieBasket = HttpContext.Request.Cookies["basket"];

            if(!string.IsNullOrWhiteSpace(cookieBasket))
            {
                List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(HttpContext.Request.Cookies["basket"]);
                List<Basket> baskets = new List<Basket>();
                List<Basket> existBasket = await _context.Baskets.Where(b => b.AppUserId == appUser.Id).ToListAsync();

                foreach (BasketVM basketVM in basketVMs)
                {
                    if (existBasket.Any(eb => eb.ProductId == basketVM.ProductId && eb.ColourId == basketVM.ColorId))
                    {
                        existBasket.Find(eb => eb.ProductId == basketVM.ProductId && eb.ColourId == basketVM.ColorId).Count = basketVM.Count;
                    }
                    else
                    {
                        Basket basket = new Basket
                        {
                            AppUserId = appUser.Id,
                            ProductId = basketVM.ProductId,
                            ColourId = basketVM.ColorId,
                            Count = basketVM.Count,
                            CreatedAt = DateTime.UtcNow.AddHours(4)
                        };
                        baskets.Add(basket);
                    }
                }

                if (baskets.Count > 0)
                {
                    await _context.Baskets.AddRangeAsync(baskets);
                    await _context.SaveChangesAsync();
                }
            }

            

            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> LogOutAsync()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }



        #region CreateMainRoles
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
        //    return Ok();
        //}
        #endregion
    }
}
