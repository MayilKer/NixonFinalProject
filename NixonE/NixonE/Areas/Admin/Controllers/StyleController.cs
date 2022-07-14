using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NixonE.DAL;
using NixonE.Extension;
using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NixonE.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class StyleController : Controller
    {
        private readonly NixonDbContext _context;
        public StyleController(NixonDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            IEnumerable<Style> styles = await _context.Styles
                .Include(t => t.Products)
                .Where(t => status == null || t.IsDeleted == status)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
            ViewBag.Status = status;
            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)styles.Count() / 5);

            return View(styles.Skip((page - 1) * 5).Take(5));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Style style)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(style.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (!Regex.IsMatch(style.Name, @"^[a-zA-Z _&]+$"))
            {
                ModelState.AddModelError("Name", "Yalniz herif ola biler");
                return View();
            }

            if (await _context.Styles.AnyAsync(s => s.Name.ToLower() == style.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            style.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Styles.AddAsync(style);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            Style style = await _context.Styles.FirstOrDefaultAsync(s => s.Id == id);
            if (style == null) return NotFound();
            return View(style);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, bool? status,Style style, int page = 1)
        {
            if (!ModelState.IsValid)
            {
                return View(style);
            }

            if (id == null) return BadRequest();

            if (id != style.Id) return NotFound();

            Style dbstyle =await _context.Styles.FirstOrDefaultAsync(s => s.Id == id);

            if (dbstyle == null) return NotFound();

            if (string.IsNullOrWhiteSpace(style.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (!Regex.IsMatch(style.Name, @"^[a-zA-Z -_&]+$"))
            {
                ModelState.AddModelError("Name", "Yalniz herif ola biler");
                return View();
            }

            if (await _context.Styles.AnyAsync(s => s.Name.ToLower() == style.Name.ToLower() && s.Id != style.Id))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            dbstyle.Name = style.Name;
            dbstyle.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new {  status, page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Style dbstyle = await _context.Styles.FirstOrDefaultAsync(t => t.Id == id);

            if (dbstyle == null) return NotFound();

            dbstyle.IsDeleted = true;
            dbstyle.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            ViewBag.Status = status;

            IEnumerable<Style> styles = await _context.Styles
                .Include(t => t.Products)
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)styles.Count() / 5);

            return PartialView("_StylePartial", styles.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Style dbstyle = await _context.Styles.FirstOrDefaultAsync(t => t.Id == id);

            if (dbstyle == null) return NotFound();

            dbstyle.IsDeleted = false;
            dbstyle.DeletedAt = null;

            await _context.SaveChangesAsync();
            ViewBag.Status = status;

            IEnumerable<Style> styles = await _context.Styles
                .Include(t => t.Products)
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)styles.Count() / 5);

            return PartialView("_StylePartial", styles.Skip((page - 1) * 5).Take(5));
        }
    }
}
