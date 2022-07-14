using Microsoft.AspNetCore.Mvc;
using NixonE.DAL;
using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly NixonDbContext _context;

        public ContactUsController(NixonDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (!ModelState.IsValid) return View();

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
