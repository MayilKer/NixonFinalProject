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
    public class MyAccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly NixonDbContext _context;
        public MyAccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, NixonDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login","Account");
            }
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(p => p.UserName == User.Identity.Name && !p.IsAdmin);

            AdressVm adressVm = new AdressVm
            {
                Adress = appUser.Adress,
                City = appUser.City,
                ZipCode = appUser.ZipCode,
                Country = appUser.Country
            };

            return View(adressVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AdressVm adressVm)
        {
            if (!ModelState.IsValid) return View();
            AppUser userex = await _userManager.GetUserAsync(HttpContext.User);
            userex.City = adressVm.City;
            userex.Country = adressVm.Country;
            userex.ZipCode = adressVm.ZipCode;
            userex.Adress = adressVm.Adress;
            await _userManager.UpdateAsync(userex);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CheckOut()
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(p => p.UserName == User.Identity.Name && !p.IsAdmin);

            string cookieBasket = HttpContext.Request.Cookies["basket"];

            if (!string.IsNullOrWhiteSpace(cookieBasket) && !string.IsNullOrEmpty(cookieBasket) && !(cookieBasket == "[]"))
            {
                List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(HttpContext.Request.Cookies["basket"]);
                List<Basket> baskets = new List<Basket>();
                List<Basket> existBasket = await _context.Baskets.Where(b => b.AppUserId == appUser.Id).ToListAsync();
                _context.Baskets.RemoveRange(existBasket);
                foreach (BasketVM basketVM in basketVMs)
                {
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
            else
            {
                return RedirectToAction("Index","Home");
            }

            if (appUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            double total = 0;
            List<Basket> basketss = await _context.Baskets.Include(p => p.Product).Include(c => c.Colour).Where(b => b.AppUserId == appUser.Id).ToListAsync();
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (Basket item in basketss)
            {
                total = total + (item.Count * item.Product.Price);
                OrderItem orderItem = new OrderItem()
                {
                    Count = item.Count,
                    ProductId = item.ProductId,
                    ColourId = item.ColourId,
                    TotalPrice = item.Count * item.Product.Price,
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    Country = item.Colour.Name

                };
                orderItems.Add(orderItem);
            }

            Order order = new Order()
            {
                Adress = appUser.Adress,
                City = appUser.City,
                Country = appUser.Country,
                ZipCode = appUser.ZipCode,
                AppUserId = appUser.Id,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                TotalPrice = total,
                OrdersItems = orderItems
            };

             _context.Baskets.RemoveRange(basketss);

            HttpContext.Response.Cookies.Append("basket", "");
            await _context.Orders.AddRangeAsync(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> GetOrders()
        {
            if(!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account");
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(p => p.UserName == User.Identity.Name && !p.IsAdmin);

            if (appUser == null) return RedirectToAction("Login", "Account");

            List<Order> orders = await _context.Orders.Include(o => o.OrdersItems).ThenInclude(p => p.Product).Include(O => O.AppUser).Where(o=>o.AppUserId == appUser.Id).ToListAsync();

            return View(orders);
        }
    }
}
