using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NixonE.DAL;
using NixonE.Models;
using NixonE.ViewModels.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Services
{
    public class LayoutService
    {
        private readonly NixonDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LayoutService(NixonDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Dictionary<string, string>> GetSettingAsync()
        {
            return await _context.Settings.ToDictionaryAsync(k => k.Key, v => v.Value);
        }
        public async Task<Banner> GetBannerAsync()
        {
            return await _context.Banners.FirstOrDefaultAsync();
        }

        public async Task<List<BasketVM>> GetBasket()
        {
            string cookieBasket = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

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
            return basketVMs;
        }
    }
}
