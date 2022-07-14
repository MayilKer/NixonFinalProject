using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(255)]
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public IEnumerable<Basket> Baskets { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

    }
}
