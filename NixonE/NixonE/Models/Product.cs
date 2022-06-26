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
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        public int Count { get; set; }
        public Nullable<int> TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
