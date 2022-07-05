using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NixonE.DAL;
using NixonE.Models;
using NixonE.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Controllers
{
    public class ProductsController : Controller
    {
        private readonly NixonDbContext _context;

        public ProductsController(NixonDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync(int? id,int? styleId,int? tagId,int? colorid,int? useId)
        {
            if (id == null) return NotFound();
            ProductsVM productsVm = new ProductsVM
            {
                Products = await _context.Products
                .Where(p => p.CategoryId == id && !p.IsDeleted)
                //.Where(t => max == null || t.Price <= max && t.Price > min)
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Include(p => p.Tag)
                .Include(p => p.Style)
                .Include(p => p.Use)
                .Include(p => p.ProductColors).ThenInclude(p => p.Colour)
                .Where(p => styleId == null || p.StyleId == styleId)
                .Where(p => tagId == null || p.TagId == tagId)
                .Where(p => useId == null || p.UseId == useId) 
                .Where(p => colorid == null || p.ProductColors.Any(c=>c.ColourId == colorid))
                .ToListAsync(),
                Styles = await _context.Styles.Where(p => p.Products.Any(p => p.CategoryId == id) && !p.IsDeleted).ToListAsync(),
                Category = await _context.Categories.Include(p=>p.Parent).FirstOrDefaultAsync(c=>c.Id == id && !c.IsDeleted),
                Tags = await _context.Tags.Where(p => p.Products.Any(p => p.CategoryId == id) && !p.IsDeleted).ToListAsync(),
                Uses = await _context.Uses.Where(u=>u.Products.Any(p=>p.CategoryId == id) && !u.IsDeleted).ToListAsync(),
                ProductColors = await _context.ProductColors.Include(c=>c.Colour).Include(p=>p.Product).Where(p=>p.Product.CategoryId == id && !p.Colour.IsDeleted).ToListAsync()
            };
            if (productsVm.Category == null) return NotFound();

            int higest = (int)productsVm.Products.Max(p => p.Price);
            int min = (int)productsVm.Products.Min(p => p.Price);
            var p = productsVm.Products.OrderBy(item => Math.Min(higest - item.Price, item.Price - min));
            return View(productsVm);
        }

    }
}
