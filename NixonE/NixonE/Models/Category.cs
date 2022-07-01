using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class Category : BaseEntity
    {
        [Required, StringLength(150)]
        public string Name { get; set; }
        [StringLength(1000)]
        [AllowNull]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile CategoryImg { get; set; }
        public bool MainCategory { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Category Parent { get; set; }
        public IEnumerable<Category> Children { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
