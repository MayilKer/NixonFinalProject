using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NixonE.DAL;
using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.ViewComponents
{
    public class TwoWayConversationViewComponent : ViewComponent
    {
        private readonly NixonDbContext _context;
        public TwoWayConversationViewComponent(NixonDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("Default", await Task.FromResult(await _context.Settings.ToDictionaryAsync(k => k.Key, v => v.Value)));
        }
    }
}
