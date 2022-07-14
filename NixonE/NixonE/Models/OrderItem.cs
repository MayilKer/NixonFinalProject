using NixonE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public OrderStatus Status { get; set; }
        public Nullable<int> ColourId { get; set; }
        public Colour Colour { get; set; }

    }
}
