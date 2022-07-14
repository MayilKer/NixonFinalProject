using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NixonE.DAL;
using NixonE.Models;
using NixonE.ViewModels.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly NixonDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ShoppingCartController(NixonDbContext context, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                Colour dbcolour = await _context.Colors.FirstOrDefaultAsync(c => c.Id == basketVM.ColorId);
                basketVM.Image = dbproduct.MainImage;
                basketVM.Price = dbproduct.Price;
                basketVM.Name = dbproduct.Name;
                basketVM.Colour = dbcolour.Name;
            }

            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

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

            return View(basketVMs);
        }
        public async Task<IActionResult> CartUpdate(int? id, int? colorId, int? count)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();


            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);

                if (!basketVMs.Any(b => b.ProductId == id && b.ColorId == colorId))
                {
                    return NotFound();
                }

                basketVMs.Find(b => b.ProductId == id && b.ColorId == colorId).Count = (int)count;
            }
            else
            {
                return BadRequest();
            }

            cookieBasket = JsonConvert.SerializeObject(basketVMs);
            HttpContext.Response.Cookies.Append("basket", cookieBasket);

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                Colour dbcolour = await _context.Colors.FirstOrDefaultAsync(c => c.Id == basketVM.ColorId);
                basketVM.Image = dbproduct.MainImage;
                basketVM.Price = dbproduct.Price;
                basketVM.Name = dbproduct.Name;
                basketVM.Colour = dbcolour.Name;
            }

            return PartialView("_ProductCartPartial", basketVMs);
        }
        public async Task<IActionResult> UpdateHeaderCart()
        {
            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                Colour dbcolour = await _context.Colors.FirstOrDefaultAsync(c => c.Id == basketVM.ColorId);
                basketVM.Image = dbproduct.MainImage;
                basketVM.Price = dbproduct.Price;
                basketVM.Name = dbproduct.Name;
                basketVM.Colour = dbcolour.Name;
            }

            return PartialView("_BasketPartial", basketVMs);
        }

        public async Task<IActionResult> DeleteFromBasket(int? id, int? colorId)
        {

            if (id == null) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();


            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;
            



            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);

                BasketVM basket = basketVMs.FirstOrDefault(p => p.ProductId == id && p.ColorId == colorId);

                if (basket == null)
                {
                    return NotFound();
                }

                basketVMs.Remove(basket);
            }
            else
            {
                return BadRequest();
            }

            cookieBasket = JsonConvert.SerializeObject(basketVMs);
            HttpContext.Response.Cookies.Append("basket", cookieBasket);

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                Colour dbcolour = await _context.Colors.FirstOrDefaultAsync(c => c.Id == basketVM.ColorId);
                basketVM.Image = dbproduct.MainImage;
                basketVM.Price = dbproduct.Price;
                basketVM.Name = dbproduct.Name;
                basketVM.Colour = dbcolour.Name;
            }

            


            return PartialView("_ProductCartPartial", basketVMs);
        }
        public async Task<IActionResult> DeleteFromBasketLayout(int? id, int? colorId)
        {

            if (id == null) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();


            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);

                BasketVM basket = basketVMs.FirstOrDefault(p => p.ProductId == id && p.ColorId == colorId);

                if (basket == null)
                {
                    return NotFound();
                }

                basketVMs.Remove(basket);
            }
            else
            {
                return BadRequest();
            }

            cookieBasket = JsonConvert.SerializeObject(basketVMs);
            HttpContext.Response.Cookies.Append("basket", cookieBasket);

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                Colour dbcolour = await _context.Colors.FirstOrDefaultAsync(c => c.Id == basketVM.ColorId);
                basketVM.Image = dbproduct.MainImage;
                basketVM.Price = dbproduct.Price;
                basketVM.Name = dbproduct.Name;
                basketVM.Colour = dbcolour.Name;
            }

            return PartialView("_BasketPartial", basketVMs);
        }
    }
}
