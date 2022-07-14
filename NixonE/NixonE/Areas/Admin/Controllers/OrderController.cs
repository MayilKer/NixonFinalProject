using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NixonE.DAL;
using NixonE.Enums;
using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class OrderController : Controller
    {
        private readonly NixonDbContext _context;

        public OrderController(NixonDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            IEnumerable<Order> orders = await _context.Orders.Include(o => o.AppUser).Include(o => o.OrdersItems).OrderByDescending(o=>o.CreatedAt).Where(o => !o.IsDeleted).ToListAsync();
            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)orders.Count() / 5);
            return View(orders.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Update(int? id,int page = 1)
        {
            if (id == null) return BadRequest();
            ViewBag.PageIndex = page;
            Order order = await _context.Orders
                .Include(o => o.AppUser)
                .Include(o => o.OrdersItems).ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);

            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, int orderStatus, int page = 1)
        {
            if (id == null) return BadRequest();

            Order order = await _context.Orders
                .Include(o => o.AppUser)
                .Include(o => o.OrdersItems).ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);

            if (order == null) return NotFound();

            if (order.Status != OrderStatus.Accepted && orderStatus == 1)
            {
                foreach (var item in order.OrdersItems)
                {
                    item.Product.Count -= item.Count;
                }
            }
            ViewBag.PageIndex = page;
            order.Status = (OrderStatus)orderStatus;
            order.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { page });
        }
        public async Task<IActionResult> Delete(int? id, int page = 1)
        {
            if (id == null) return NotFound();
            Order order = await _context.Orders.FirstOrDefaultAsync(c => c.Id == id);
            if (order == null) return NotFound();
            ViewBag.PageIndex = page;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { page });
        }
    }
}
