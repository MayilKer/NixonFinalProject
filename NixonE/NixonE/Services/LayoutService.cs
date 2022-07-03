using Microsoft.EntityFrameworkCore;
using NixonE.DAL;
using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Services
{
    public class LayoutService
    {
        private readonly NixonDbContext _context;
        public LayoutService(NixonDbContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<string, string>> GetSettingAsync()
        {
            return await _context.Settings.ToDictionaryAsync(k => k.Key, v => v.Value);
        }
        public async Task<Banner> GetBannerAsync()
        {
            return await _context.Banners.FirstOrDefaultAsync();
        }
    }
}
