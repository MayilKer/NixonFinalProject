using NixonE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class Order : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public double TotalPrice { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderItem> OrdersItems { get; set; }
    }
}
