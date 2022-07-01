using Microsoft.EntityFrameworkCore;
using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.DAL
{
    public class NixonDbContext : DbContext
    {
        public NixonDbContext(DbContextOptions<NixonDbContext> options) : base(options){ }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Use> Uses { get; set; }
        public DbSet<Colour> Colors { get; set; }
        public DbSet<ProductColors> ProductColors { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
    }
}
