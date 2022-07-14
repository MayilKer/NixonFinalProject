using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NixonE.DAL;
using NixonE.ViewModels.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly NixonDbContext _context;
        public HeaderViewComponent(NixonDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HeaderVM headerVM = new HeaderVM
            {
                categories = await _context.Categories.Where(c => !c.IsDeleted).OrderByDescending(c => c.CreatedAt).Include(c=>c.Children).Include(c=>c.Parent).ToListAsync(),
                tags = await _context.Tags.Where(c => !c.IsDeleted).Include(p=>p.Products).OrderByDescending(c => c.CreatedAt).ToListAsync(),
                styles = await _context.Styles.Where(c => !c.IsDeleted).Include(p=>p.Products).OrderByDescending(c => c.CreatedAt).ToListAsync(),
                uses = await _context.Uses.Where(c => !c.IsDeleted).Include(p=>p.Products).OrderByDescending(c => c.CreatedAt).ToListAsync(),
                products = await _context.Products.Where(c => !c.IsDeleted).Include(S=>S.Style).Include(C=>C.Category).ThenInclude(p=>p.Parent).ToListAsync(),
            };

            return View("Index",await Task.FromResult(headerVM));
        }
    }
}
