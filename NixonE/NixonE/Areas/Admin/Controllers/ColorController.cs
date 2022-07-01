using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NixonE.DAL;
using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NixonE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly NixonDbContext _context;
        public ColorController(NixonDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            IEnumerable<Colour> colours = await _context.Colors
                .Include(t => t.ProductColors)
                .Where(t => status == null || t.IsDeleted == status)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
            ViewBag.Status = status;
            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)colours.Count() / 5);

            return View(colours.Skip((page - 1) * 5).Take(5));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Colour colour)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(colour.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (!Regex.IsMatch(colour.Name, @"^[a-zA-Z /&-]+$"))
            {
                ModelState.AddModelError("Name", "Yalniz herif ola biler");
                return View();
            }

            if (await _context.Colors.AnyAsync(s => s.Name.ToLower() == colour.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            colour.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Colors.AddAsync(colour);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            Colour colour = await _context.Colors.FirstOrDefaultAsync(s => s.Id == id);
            if (colour == null) return NotFound();
            return View(colour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, bool? status, Colour colour, int page = 1)
        {
            if (!ModelState.IsValid)
            {
                return View(colour);
            }

            if (id == null) return BadRequest();

            if (id != colour.Id) return NotFound();

            Colour dbcolour = await _context.Colors.FirstOrDefaultAsync(s => s.Id == id);

            if (dbcolour == null) return NotFound();

            if (string.IsNullOrWhiteSpace(colour.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (!Regex.IsMatch(colour.Name, @"^[a-zA-Z /&-]+$"))
            {
                ModelState.AddModelError("Name", "Yalniz herif ola biler");
                return View();
            }

            if (await _context.Colors.AnyAsync(s => s.Name.ToLower() == colour.Name.ToLower() && s.Id != colour.Id))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            dbcolour.Name = colour.Name;
            dbcolour.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status, page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Colour dbcolour = await _context.Colors.FirstOrDefaultAsync(t => t.Id == id);

            if (dbcolour == null) return NotFound();

            dbcolour.IsDeleted = true;
            dbcolour.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            ViewBag.Status = status;

            IEnumerable<Colour> colours = await _context.Colors
                .Include(t => t.ProductColors)
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)colours.Count() / 5);

            return PartialView("_ColourPartial", colours.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Colour dbcolour = await _context.Colors.FirstOrDefaultAsync(t => t.Id == id);

            if (dbcolour == null) return NotFound();

            dbcolour.IsDeleted = false;
            dbcolour.DeletedAt = null;

            await _context.SaveChangesAsync();
            ViewBag.Status = status;

            IEnumerable<Colour> colours = await _context.Colors
                .Include(t => t.ProductColors)
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)colours.Count() / 5);

            return PartialView("_ColourPartial", colours.Skip((page - 1) * 5).Take(5));
        }
    }
}
