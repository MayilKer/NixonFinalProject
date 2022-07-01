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
    public class UseController : Controller
    {
        private readonly NixonDbContext _context;
        public UseController(NixonDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            IEnumerable<Use> uses = await _context.Uses
                .Include(t => t.Products)
                .Where(t => status == null || t.IsDeleted == status)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
            ViewBag.Status = status;
            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)uses.Count() / 5);

            return View(uses.Skip((page - 1) * 5).Take(5));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Use use)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(use.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (!Regex.IsMatch(use.Name, @"^[a-zA-Z /&-]+$"))
            {
                ModelState.AddModelError("Name", "Yalniz herif ola biler");
                return View();
            }

            if (await _context.Uses.AnyAsync(s => s.Name.ToLower() == use.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            use.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Uses.AddAsync(use);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            Use use = await _context.Uses.FirstOrDefaultAsync(s => s.Id == id);
            if (use == null) return NotFound();
            return View(use);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, bool? status, Use use, int page = 1)
        {
            if (!ModelState.IsValid)
            {
                return View(use);
            }

            if (id == null) return BadRequest();

            if (id != use.Id) return NotFound();

            Use dbuse = await _context.Uses.FirstOrDefaultAsync(s => s.Id == id);

            if (dbuse == null) return NotFound();

            if (string.IsNullOrWhiteSpace(use.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            if (!Regex.IsMatch(use.Name, @"^[a-zA-Z /&-]+$"))
            {
                ModelState.AddModelError("Name", "Yalniz herif ola biler");
                return View();
            }

            if (await _context.Uses.AnyAsync(s => s.Name.ToLower() == use.Name.ToLower() && s.Id != use.Id))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            dbuse.Name = use.Name;
            dbuse.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status, page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Use dbuse = await _context.Uses.FirstOrDefaultAsync(t => t.Id == id);

            if (dbuse == null) return NotFound();

            dbuse.IsDeleted = true;
            dbuse.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            ViewBag.Status = status;

            IEnumerable<Use> uses = await _context.Uses
                .Include(t => t.Products)
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)uses.Count() / 5);

            return PartialView("_UsePartial", uses.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Use dbuse = await _context.Uses.FirstOrDefaultAsync(t => t.Id == id);

            if (dbuse == null) return NotFound();

            dbuse.IsDeleted = false;
            dbuse.DeletedAt = null;

            await _context.SaveChangesAsync();
            ViewBag.Status = status;

            IEnumerable<Use> uses = await _context.Uses
                .Include(t => t.Products)
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)uses.Count() / 5);

            return PartialView("_UsePartial", uses.Skip((page - 1) * 5).Take(5));
        }
    }
}
