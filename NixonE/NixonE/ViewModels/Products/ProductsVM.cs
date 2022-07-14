using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.ViewModels.Products
{
    public class ProductsVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Style> Styles { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public Category Category { get; set; }
        public IEnumerable<ProductColors> ProductColors { get; set; }
        public IEnumerable<Use> Uses { get; set; }
        public IEnumerable<Colour> Colours { get; set; }
    }
}
