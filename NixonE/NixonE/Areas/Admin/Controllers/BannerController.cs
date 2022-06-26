using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NixonE.DAL;
using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BannerController : Controller
    {
        private readonly NixonDbContext _context;
        public BannerController(NixonDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            Banner banner = await _context.Banners.FirstOrDefaultAsync();
            return View(banner);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            Banner banner = await _context.Banners.FirstOrDefaultAsync(b => b.Id == id);
            if (banner == null) return NotFound();

            return View(banner);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Banner banner, int? id)
        {
            if (!ModelState.IsValid) return View(banner);

            if (id == null) return BadRequest();
            if (banner.Id != id) return NotFound();

            Banner dbBanner =await _context.Banners.FirstOrDefaultAsync(b => b.Id == banner.Id);

            if (dbBanner == null) return NotFound();

            banner.Content.Trim();

            dbBanner.Content = banner.Content;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
