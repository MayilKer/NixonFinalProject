using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class Style : BaseEntity
    {
        [Required,StringLength(25)]
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
