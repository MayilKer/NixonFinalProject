using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.ViewModels.Acoount
{
    public class AdressVm
    {
        [StringLength(255), Required]
        public string Adress { get; set; }
        [StringLength(255), Required]
        public string Country { get; set; }
        [StringLength(255), Required]
        public string City { get; set; }
        [StringLength(255), Required]
        public string ZipCode { get; set; }
    }
}
