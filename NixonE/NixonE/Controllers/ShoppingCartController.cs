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

        public ShoppingCartController(NixonDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
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

            return View(basketVMs);
        }
        public async Task<IActionResult> CartUpdate(int? id, int? colorId, int? count)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();


            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (cookieBasket != null)
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

            return PartialView("_BasketPartial", basketVMs);
        }
    }
}
