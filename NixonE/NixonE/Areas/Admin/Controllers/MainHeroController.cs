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
    public class MainHeroController : Controller
    {
        private readonly NixonDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MainHeroController(NixonDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            MainHero mainhero = await _context.MainHeroes.FirstOrDefaultAsync();
            return View(mainhero);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            MainHero mainHero = await _context.MainHeroes.FirstOrDefaultAsync(m => m.Id == id);
            if (mainHero == null) return BadRequest();
            return View(mainHero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, MainHero mainhero)
        {
            if (!ModelState.IsValid)
            {
                return View(mainhero);
            }

            if (id == null) return NotFound();

            MainHero dbMainhero = await _context.MainHeroes.FirstOrDefaultAsync(m => m.Id == id);

            if (dbMainhero == null) return BadRequest();

            if(mainhero.HeroImgWebFile != null)
            {
                Helper.DeleteFile(_env, dbMainhero.HeroImgWeb, "dist", "images", "MainHero");
                dbMainhero.HeroImgWeb = mainhero.HeroImgWebFile.CreateFile(_env, "dist", "images", "MainHero");
            }

            if (mainhero.HeroImgMobFile != null)
            {
                Helper.DeleteFile(_env, dbMainhero.HeroImgMob, "dist", "images", "MainHero");
                dbMainhero.HeroImgMob = mainhero.HeroImgMobFile.CreateFile(_env, "dist", "images", "MainHero");
            }

            dbMainhero.Title = mainhero.Title;
            dbMainhero.Content = mainhero.Content;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");


        }
    }
}
