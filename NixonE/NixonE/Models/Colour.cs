﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class Colour : BaseEntity
    {
        [Required(ErrorMessage = "Renq mutleq olamlidir"), StringLength(50)]
        public string Name { get; set; }
        public List<ProductColors> ProductColors { get; set; }
        public IEnumerable<Basket> Baskets { get; set; }
        public IEnumerable<OrderItem> orderItems { get; set; }
    }
}
