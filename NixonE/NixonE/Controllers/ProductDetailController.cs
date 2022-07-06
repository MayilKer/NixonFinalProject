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
    public class ProductDetailController : Controller
    {
        private readonly NixonDbContext _context;

        public ProductDetailController(NixonDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) return NotFound();
            ViewBag.Colour = await _context.Colors.Where(c => !c.IsDeleted).ToListAsync();
            Product product = await _context.Products
                .Include(p=>p.Category).ThenInclude(p=>p.Parent)
                .Include(p=>p.Tag)
                .Include(p=>p.Style)
                .Include(p=>p.ProductColors).ThenInclude(p=>p.Colour)
                .Include(p=>p.ProductFeatures)
                .Include(p=>p.ProductImages)
                .Where(p=>p.ProductColors.Any(p=>p.Count > 0))
                .FirstOrDefaultAsync(p=>p.Id == id && !p.IsDeleted && p.Availability);

            if (product == null) return NotFound();

            return View(product);
        }

        public async Task<IActionResult> AddBasket(int? id,int? colorId, int count = 1)
        {
            if (id == null) return BadRequest();

            if (colorId == null) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            Colour colour = await _context.Colors.FirstOrDefaultAsync(c => c.Id == colorId);

            if (colour == null) return BadRequest();

            if (product == null) return NotFound();


            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (cookieBasket != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);

                if (basketVMs.Any(b => b.ProductId == id && b.ColorId == colorId))
                {
                    basketVMs.Find(b => b.ProductId == id && b.ColorId == colorId).Count += count;
                }
                else
                {
                    basketVMs.Add(new BasketVM
                    {
                        ProductId = (int)id,
                        Count = count,
                        ColorId = (int)colorId
                    });
                }
            }
            else
            {
                basketVMs = new List<BasketVM>();
                basketVMs.Add(new BasketVM
                {
                    ProductId = (int)id,
                    Count = count,
                    ColorId = (int)colorId
                });
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
        public async Task<IActionResult> GetBasketCount()
        {
            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (cookieBasket != null)
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
            return PartialView("_ProductCountPartial", basketVMs);
        }
    }
}
