using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NixonE.DAL;
using NixonE.Models;
using NixonE.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Controllers
{
    public class HomeController : Controller
    {
        private readonly NixonDbContext _context;

        public HomeController(NixonDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                categories = await _context.Categories.Where(c => !c.IsDeleted && c.MainCategory).Include(c => c.Children).ToListAsync(),
                mainHero = await _context.MainHeroes.FirstOrDefaultAsync(),
                products = await _context.Products.Where(p => !p.IsDeleted).OrderByDescending(p => p.CreatedAt).Include(p => p.ProductImages).ToListAsync(),
                OfferHeroes = await _context.OfferHeroes.ToListAsync()
            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
