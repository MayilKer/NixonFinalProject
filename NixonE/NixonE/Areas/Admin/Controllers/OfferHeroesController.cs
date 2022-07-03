using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NixonE.DAL;
using NixonE.Extension;
using NixonE.Helpers;
using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferHeroesController : Controller
    {
        public readonly NixonDbContext _context;
        private readonly IWebHostEnvironment _env;
        public OfferHeroesController(NixonDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.OfferHeroes.ToListAsync());
        }
        
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            OfferHeroes offer = await _context.OfferHeroes.FirstOrDefaultAsync(o=>o.Id == id);

            if (offer == null) return NotFound();

            return View(offer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, OfferHeroes offer)
        {
            if (!ModelState.IsValid) return View(offer);

            if (id == null) return BadRequest();

            OfferHeroes offerdb = await _context.OfferHeroes.FirstOrDefaultAsync(d => d.Id == id);

            if (offerdb == null) return NotFound();

            if (offer.Id != id) return NotFound();

            if (offer.ImageFileWeb != null)
            {

                Helper.DeleteFile(_env, offerdb.ImageWeb, "dist", "images", "Offers");
                offerdb.ImageWeb = offer.ImageFileWeb.CreateFile(_env, "dist", "images", "Offers");
            }
            if (offer.ImageFileMob != null)
            {

                Helper.DeleteFile(_env, offerdb.ImageMob, "dist", "images", "Offers");
                offerdb.ImageMob = offer.ImageFileMob.CreateFile(_env, "dist", "images", "Offers");
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
