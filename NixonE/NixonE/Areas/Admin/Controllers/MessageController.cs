using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class MessageController : Controller
    {
        private readonly NixonDbContext _context;
        public MessageController(NixonDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync(int page = 1)
        {
            ViewBag.PageIndex = page;
            IEnumerable<Contact> products = await _context.Contacts
                .ToListAsync();

            ViewBag.PageCount = Math.Ceiling((double)products.Count() / 5);

            return View(products.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Contact contact = await _context.Contacts.FirstOrDefaultAsync(c=>c.Id == id);

            if (contact == null) return NotFound();

            return View(contact);
        }

        public async Task<IActionResult> Delete(int? id,int page = 1)
        {
            if (id == null) return NotFound();
            Contact contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (contact == null) return NotFound();
            ViewBag.PageIndex = page;
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { page });
        }
    }
}
