using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class ProductFeatures
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
