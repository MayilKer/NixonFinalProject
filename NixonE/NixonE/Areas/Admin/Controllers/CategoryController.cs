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
    public class CategoryController : Controller
    {
        public readonly NixonDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CategoryController(NixonDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(bool? status, bool? isMainRoute, int page = 1)
        {
            IEnumerable<Category> categories = await _context.Categories
                .Include(t => t.Products)
                .Where(t => status == null || t.IsDeleted == status)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
            ViewBag.IsMain = isMainRoute;
            ViewBag.Status = status;
            ViewBag.PageIndex = page;
            if (isMainRoute != null)
                categories = categories.Where(c => c.MainCategory == isMainRoute);
            ViewBag.PageCount = Math.Ceiling((double)categories.Count() / 5);
            return View(categories.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => c.MainCategory && !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category, bool? status, bool? isMainRoute, int page = 1)
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => c.MainCategory && !c.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            //tag.Name = tag.Name.Trim();

            if (await _context.Categories.AnyAsync(t => t.Name.ToLower() == category.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            if (category.MainCategory)
            {
                category.ParentId = null;

                if (category.CategoryImg == null)
                {
                    ModelState.AddModelError("CategoryImg", "Sekil Mutleq Olmalidi");
                    return View();
                }

                category.Image = category.CategoryImg.CreateFile(_env, "dist", "images", "CategoryImg");
            }
            else
            {
                if (category.ParentId == null)
                {
                    ModelState.AddModelError("ParentId", "Parent Mutleq Secilmelidir");
                    return View();
                }

                if (!await _context.Categories.AnyAsync(c => c.Id == category.ParentId && !c.IsDeleted && c.MainCategory))
                {
                    ModelState.AddModelError("ParentId", "Parent Id yanlisdir");
                    return View();
                }
            }

            category.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status, isMainRoute, page });
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound();

            ViewBag.MainCategory = await _context.Categories.Where(c => c.Id != id && c.MainCategory && !c.IsDeleted).ToListAsync();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category category, bool? status, bool? isMainRoute, int page = 1)
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => c.Id != id && c.MainCategory && !c.IsDeleted).ToListAsync();

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (dbCategory == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbCategory);
            }

            if (id != category.Id) return BadRequest();

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View(dbCategory);
            }

            if (await _context.Categories.AnyAsync(t => t.Id != id && t.Name.ToLower() == category.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(dbCategory);
            }

            if (category.ParentId != null && id == category.ParentId)
            {
                ModelState.AddModelError("ParentId", "Duzgun Parent Sec");
                return View(category);
            }

            if (category.MainCategory)
            {
                if (!dbCategory.MainCategory && category.CategoryImg == null)
                {
                    ModelState.AddModelError("CategoryImage", "Sekil Mutleq Olmalidi");
                    return View(dbCategory);
                }

                if (category.CategoryImg != null)
                {

                    if (dbCategory.Image != null)
                    {
                        Helper.DeleteFile(_env, dbCategory.Image, "dist", "images", "CategoryImg");
                    }

                    dbCategory.Image = category.CategoryImg.CreateFile(_env, "dist", "images", "CategoryImg");
                }

                dbCategory.ParentId = null;
            }
            else
            {
                if (category.ParentId == null)
                {
                    ModelState.AddModelError("ParentId", "Parent Mutleq Secilmelidir");
                    return View(dbCategory);
                }

                if (!await _context.Categories.AnyAsync(c => c.Id == category.ParentId && !c.IsDeleted && c.MainCategory))
                {
                    ModelState.AddModelError("ParentId", "Parent Id yanlisdir");
                    return View(dbCategory);
                }

                dbCategory.ParentId = category.ParentId;
                Helper.DeleteFile(_env, dbCategory.Image, "dist", "images", "CategoryImg");
                dbCategory.Image = null;
            }

            dbCategory.MainCategory = category.MainCategory;
            dbCategory.Name = category.Name;
            dbCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status, isMainRoute, page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, bool? isMainRoute, int page = 1)
        {
            if (id == null) return BadRequest();

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(t => t.Id == id);

            if (dbCategory == null) return NotFound();

            dbCategory.IsDeleted = true;
            dbCategory.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            ViewBag.Status = status;
            ViewBag.IsMain = isMainRoute;

            IEnumerable<Category> categories = await _context.Categories
                .Include(t => t.Products)
                .Where(t => status != null ? t.IsDeleted == status : true && isMainRoute != null ? t.MainCategory == isMainRoute : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)categories.Count() / 5);

            return PartialView("_CategoryPartial", categories.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Restore(int? id, bool? status, bool? isMainRoute, int page = 1)
        {
            if (id == null) return BadRequest();

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(t => t.Id == id);

            if (dbCategory == null) return NotFound();

            dbCategory.IsDeleted = false;

            await _context.SaveChangesAsync();

            ViewBag.Status = status;
            ViewBag.IsMain = isMainRoute;

            IEnumerable<Category> categories = await _context.Categories
                .Include(t => t.Products)
                .Where(t => status != null ? t.IsDeleted == status : true && isMainRoute != null ? t.MainCategory == isMainRoute : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)categories.Count() / 5);

            return PartialView("_CategoryPartial", categories.Skip((page - 1) * 5).Take(5));
        }
    }
}
