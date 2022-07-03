using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class ProductController : Controller
    {
        private readonly NixonDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(NixonDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;
            ViewBag.PageIndex = page;
            IEnumerable<Product> products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Tag)
                .Include(p => p.Use)
                .Include(p=>p.ProductColors).ThenInclude(c => c.Colour)
                .Include(p => p.Style)
                .Include(p => p.ProductFeatures)
                .Where(t => status == null || t.IsDeleted == status)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageCount = Math.Ceiling((double)products.Count() / 5);

            return View(products.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();
            ViewBag.Use = await _context.Uses.Where(s => !s.IsDeleted).ToListAsync();
            ViewBag.Colour = await _context.Colors.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Styles = await _context.Styles.Where(c => !c.IsDeleted).ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, bool? status, int page = 1)
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();
            ViewBag.Use = await _context.Uses.Where(s => !s.IsDeleted).ToListAsync();
            ViewBag.Colour = await _context.Colors.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Styles = await _context.Styles.Where(c => !c.IsDeleted).ToListAsync();


            if (!ModelState.IsValid) return View(product);

            if(product.ColourIds.Count == 0 && product.Key.Count == 0)
            {
                ModelState.AddModelError("", "Renq ve ya Feature minimum bir dene ola biler Mutleq olmalidir");
                return View(product);
            }

            if (!await _context.Categories.AnyAsync(c => c.Id == product.CategoryId && !c.IsDeleted))
            {
                ModelState.AddModelError("CategoryId", "Categoriya duzgun secilmiyib");
                return View(product);
            }

            if (product.ColourIds.Count != product.Counts.Count || product.Key.Count != product.Value.Count)
            {
                ModelState.AddModelError("", "Incorrect");
                return View();
            }

            if (product.ColourIds.Count() > 0)
            {
                List<ProductColors> productColors = new List<ProductColors>();
                for (int i = 0; i < product.ColourIds.Count; i++)
                {
                    ProductColors productColor = new ProductColors
                    {
                        ColourId = product.ColourIds[i],
                        Count = product.Counts[i]
                    };
                    productColors.Add(productColor);
                }
                product.ProductColors = productColors;
            }

            if(product.Value.Count() > 0)
            {
                List<ProductFeatures> productFeatures = new List<ProductFeatures>();

                for (int i = 0; i < product.Key.Count; i++)
                {
                    ProductFeatures productFeature = new ProductFeatures
                    {
                        Key = product.Key[i],
                        Value = product.Value[i]
                    };
                    productFeatures.Add(productFeature);
                }
                product.ProductFeatures = productFeatures;
            }

            

            if (!await _context.Styles.AnyAsync(s => s.Id == product.StyleId && !s.IsDeleted))
            {
                ModelState.AddModelError("StyleId", "Style Mutleq Olmalidir");
                return View(product);
            }

            if (!await _context.Uses.AnyAsync(s => s.Id == product.UseId && !s.IsDeleted))
            {
                ModelState.AddModelError("UseId", "Usage Mutleq Bilindirilmelidi");
                return View(product);
            }

            if(product.ProductImagesFile.Count() <= 0)
            {
                ModelState.AddModelError("ProductImagesFile", "Mehsulun Sekileri mutleq olmalidir");
                return View(product);
            }

            if (product.MainImgFile != null)
            {

                product.MainImage = product.MainImgFile.CreateFile(_env, "dist", "images", "products");
            }
            else
            {
                ModelState.AddModelError("MainImgFile", "Esas sekil mutleq olmalidir");
                return View(product);
            }

            if (product.ProductImagesFile.Count() > 0)
            {
                if (product.ProductImagesFile.Count() > 10)
                {
                    ModelState.AddModelError("ProductImagesFile", "Max 10 sekil olar");
                    return View(product);
                }
                List<ProductImages> productImages = new List<ProductImages>();
                foreach (IFormFile item in product.ProductImagesFile)
                {
                    if (item != null)
                    {
                        ProductImages productImage = new ProductImages
                        {
                            Image = item.CreateFile(_env, "dist", "images", "products"),
                            CreatedAt = DateTime.UtcNow.AddHours(4)
                        };
                        productImages.Add(productImage);
                    }

                }
                product.ProductImages = productImages;
            }
            else
            {
                ModelState.AddModelError("ProductImagesFile", "Mutleq sekilleri secmelisiniz");
                return View(product);
            }

            product.CreatedAt = DateTime.UtcNow.AddHours(4);
            product.Count = product.Counts.Sum();
            product.Availability = product.Count > 0 ? true : false;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status, page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();
            ViewBag.Use = await _context.Uses.Where(s => !s.IsDeleted).ToListAsync();
            ViewBag.Colour = await _context.Colors.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Styles = await _context.Styles.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Features = await _context.ProductFeatures.ToListAsync();

            if (id == null) return BadRequest();

            Product products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Tag)
                .Include(p => p.Use)
                .Include(p => p.ProductColors).ThenInclude(c => c.Colour)
                .Include(p => p.Style)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (products == null) return NotFound();

            products.ColourIds = products.ProductColors.Select(pt => pt.Colour.Id).ToList();
            products.Key = products.ProductFeatures.Select(p => p.Key).ToList();
            products.Value = products.ProductFeatures.Select(p => p.Value).ToList();

            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Product product, bool? status, int page = 1)
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();
            ViewBag.Use = await _context.Uses.Where(s => !s.IsDeleted).ToListAsync();
            ViewBag.Colour = await _context.Colors.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Styles = await _context.Styles.Where(c => !c.IsDeleted).ToListAsync();

            Product dbproduct = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Tag)
                .Include(p => p.Use)
                .Include(p => p.ProductColors).ThenInclude(c => c.Colour)
                .Include(p => p.Style)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product.ColourIds.Count != product.Counts.Count || product.Key.Count != product.Value.Count)
            {
                ModelState.AddModelError("", "Incorrect Color or Count");
                return View(dbproduct);
            }

            if (!ModelState.IsValid)
            {
                return View(dbproduct);
            }

            if (id == null) return BadRequest();
            if (id != product.Id) return BadRequest();



            if (dbproduct == null) return NotFound();


            if (product.ProductImagesFile != null && product.ProductImagesFile.Length > (10 - dbproduct.ProductImages.Where(p => !p.IsDeleted).Count()))
            {
                ModelState.AddModelError("ProductImagesFile", $"Limiti kecdiz, Siz {10 - dbproduct.ProductImages.Where(p => !p.IsDeleted).Count()}-dene sekil elave eliye bilersiz");
                return View(dbproduct);
            }


            if (!await _context.Categories.AnyAsync(c => c.Id == product.CategoryId && !c.IsDeleted))
            {
                ModelState.AddModelError("CategoryId", "Category duzgun secilmeyib");
                return View(dbproduct);
            }

            if (!await _context.Uses.AnyAsync(u=>u.Id == product.UseId && !u.IsDeleted))
            {
                ModelState.AddModelError("UseId", "Usage sef secilib");
                return View(dbproduct);
            }

            if (!await _context.Styles.AnyAsync(u => u.Id == product.StyleId && !u.IsDeleted))
            {
                ModelState.AddModelError("StyleId", "Style sef secilib");
                return View(dbproduct);
            }

            if (!await _context.Tags.AnyAsync(u => u.Id == product.TagId && !u.IsDeleted))
            {
                ModelState.AddModelError("TagId", "Tag sef secilib");
                return View(dbproduct);
            }


            foreach (int colourId in product.ColourIds)
            {
                if (!await _context.Colors.AnyAsync(s => s.Id == colourId))
                {
                    ModelState.AddModelError("", "Incorrect colour");
                    return View();
                }
            }

            if (product.ColourIds.Count() > 0)
            {
                _context.ProductColors.RemoveRange(dbproduct.ProductColors);

                List<ProductColors> productColors = new List<ProductColors>();
                for (int i = 0; i < product.ColourIds.Count; i++)
                {
                    ProductColors productColor = new ProductColors
                    {
                        ColourId = product.ColourIds[i],
                        Count = product.Counts[i]
                    };
                    productColors.Add(productColor);
                }
                product.ProductColors = productColors;
                dbproduct.ProductColors = product.ProductColors;
            }
            else
            {
                ModelState.AddModelError("", "Renq mutlrq secmelisiniz");
                return View(dbproduct);
            }





            if (product.Value.Count() > 0)
            {
                _context.ProductFeatures.RemoveRange(dbproduct.ProductFeatures);

                List<ProductFeatures> productFeatures = new List<ProductFeatures>();

                for (int i = 0; i < product.Value.Count || i < product.Key.Count; i++)
                {
                    if(product.Key[i] != null && product.Value[i] != null)
                    {
                        ProductFeatures productFeature = new ProductFeatures
                        {
                            Key = product.Key[i],
                            Value = product.Value[i]
                        };
                        productFeatures.Add(productFeature);
                    }
                    
                }
                product.ProductFeatures = productFeatures;
                dbproduct.ProductFeatures = product.ProductFeatures;
            }
            else
            {
                ModelState.AddModelError("", "Produklarin Features leri olmalidir");
                return View(product);
            }

            if (product.MainImgFile != null)
            {

                Helper.DeleteFile(_env, dbproduct.MainImage, "dist", "images", "products");

                dbproduct.MainImage = product.MainImgFile.CreateFile(_env, "dist", "images", "products");
            }

            if (product.ProductImagesFile != null && product.ProductImagesFile.Count() > 0)
            {
                List<ProductImages> productImages = new List<ProductImages>();
                foreach (IFormFile item in product.ProductImagesFile)
                {
                    if (item != null)
                    {
                        ProductImages productImage = new ProductImages
                        {
                            Image = item.CreateFile(_env, "dist", "images", "products"),
                            CreatedAt = DateTime.UtcNow.AddHours(4)
                        };
                        productImages.Add(productImage);
                    }

                }
                dbproduct.ProductImages.AddRange(productImages);
            }

            dbproduct.Count = product.Counts.Sum();
            _ = dbproduct.Count > 0 ? dbproduct.Availability = true : dbproduct.Availability = false;
            dbproduct.CategoryId = product.CategoryId;
            dbproduct.Description = product.Description;
            dbproduct.Name = product.Name;
            dbproduct.Price = product.Price;
            dbproduct.StyleId = product.StyleId;
            dbproduct.UseId = product.UseId;
            dbproduct.TagId = product.TagId;
            dbproduct.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status, page });
        }
        public async Task<IActionResult> GetFormColorCount()
        {
            ViewBag.Colour = await _context.Colors.Where(c => !c.IsDeleted).ToListAsync();

            return PartialView("_ProductColorPartial");
        }
        public IActionResult GetFormProductFeatures()
        {
            return PartialView("_ProductFeaturesPartial");
        }

        public async Task<IActionResult> DeleteImage(int? id)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products.Include(pi => pi.ProductImages).FirstOrDefaultAsync(p => p.ProductImages.Any(pi => pi.Id == id && !pi.IsDeleted));

            if (product == null) return BadRequest();

            ProductImages proimg = product.ProductImages.FirstOrDefault(p => p.Id == id);

            Helper.DeleteFile(_env, proimg.Image, "dist", "images", "products");

            product.ProductImages.FirstOrDefault(p => p.Id == id).IsDeleted = true;
            product.ProductImages.FirstOrDefault(p => p.Id == id).DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_ProductDeleteImages", product.ProductImages.Where(p => !p.IsDeleted));
        }
        public async Task<IActionResult> Detail(int? id, bool? status, int page = 1)
        {
            ViewBag.Status = status;
            ViewBag.PageIndex = page;
            if (id == null) return BadRequest();

            Product products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Tag)
                .Include(p => p.Use)
                .Include(p => p.ProductColors).ThenInclude(c => c.Colour)
                .Include(p => p.Style)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (products == null) return NotFound();

            return View(products);
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            ViewBag.Status = status;
            ViewBag.PageIndex = page;

            Product products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Tag)
                .Include(p => p.Use)
                .Include(p => p.ProductColors).ThenInclude(c => c.Colour)
                .Include(p => p.Style)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (products == null) return NotFound();

            return View(products);
        }
        public async Task<IActionResult> DeleteProduct(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Product products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Tag)
                .Include(p => p.Use)
                .Include(p => p.ProductColors).ThenInclude(c => c.Colour)
                .Include(p => p.Style)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (products == null) return NotFound();

            products.IsDeleted = true;
            products.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }

        public async Task<IActionResult> Restore(int? id,bool? status,int page = 1)
        {
            if (id == null) return BadRequest();

            Product products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Tag)
                .Include(p => p.Use)
                .Include(p => p.ProductColors).ThenInclude(c => c.Colour)
                .Include(p => p.Style)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted);

            if (products == null) return NotFound();

            products.IsDeleted = false;
            products.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { status, page });
        }
    }

}
