using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SettingsController : Controller
    {
        private readonly NixonDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SettingsController(NixonDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> setting = await _context.Settings.ToDictionaryAsync(k => k.Key, v => v.Value);

            return View(setting);
        }

        public async Task<IActionResult> Update(string key)
        {
            if (key == null) return BadRequest();
            Settings setting = await _context.Settings.FirstOrDefaultAsync(k => k.Key == key);
            if (setting == null) return NotFound();
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string key, Settings setting)
        {
            if (!ModelState.IsValid)
            {
                return View(setting);
            }

            if (key == null) return BadRequest();
            if (key != setting.Key) return NotFound();

            Settings dbSetting = await _context.Settings.FirstOrDefaultAsync(k => k.Key == key);

            if (dbSetting == null) return NotFound();

            if (setting.Key == "Logo")
            {
                if (setting.LogoImg != null)
                {
                    if (!setting.LogoImg.CheckFileSize(300))
                    {
                        ModelState.AddModelError("LogoImg", "Secilen Seklin Olcusu Maksimum 300 Kb Ola Biler");
                        return View(setting);
                    }

                    if (!setting.LogoImg.CheckFileContentType("image/jpeg"))
                    {
                        ModelState.AddModelError("LogoImg", "Secilen Seklin Novu Uygun Deil");
                        return View(setting);
                    }

                    Helper.DeleteFile(_env, dbSetting.Value, "dist", "images", "main_logo");

                    dbSetting.Value = setting.LogoImg.CreateFile(_env, "dist", "images", "main_logo");
                }

            }
            else
            {
                dbSetting.Value = setting.Value;
            }

            

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
