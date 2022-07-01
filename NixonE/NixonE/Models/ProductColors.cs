using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class ProductColors
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Colour Colour { get; set; }
        public Nullable<int> ColourId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Count { get; set; }
    }
}
