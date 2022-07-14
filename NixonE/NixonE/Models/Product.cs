using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class Product : BaseEntity
    {
        [StringLength(255), Required]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Qiymeti mutleq bilindirmelidir")]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        public string MainImage { get; set; }
        [NotMapped]
        public IFormFile MainImgFile { get; set; }
        public int Count { get; set; }
        public Nullable<int> TagId { get; set; }
        public Tag Tag { get; set; }
        public Nullable<int> StyleId { get; set; }
        public Style Style { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Category Category { get; set; }
        public Nullable<int> UseId { get; set; }
        public Use Use { get; set; }
        public List<ProductColors> ProductColors { get; set; }
        [NotMapped]
        public List<int> ColourIds { get; set; } = new List<int>();
        public List<ProductImages> ProductImages { get; set; }
        [NotMapped]
        public IFormFile[] ProductImagesFile { get; set; }
        public bool Availability { get; set; }
        [NotMapped]
        public List<int> Counts { get; set; } = new List<int>();
        [NotMapped]
        public List<string> Key { get; set; } = new List<string>();
        [NotMapped]
        public List<string> Value { get; set; } = new List<string>();
        public List<ProductFeatures> ProductFeatures { get; set; }
        public IEnumerable<Basket> Baskets { get; set; }
    }
}
