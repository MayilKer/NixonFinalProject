using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<Product> products { get; set; }
        public MainHero mainHero { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<OfferHeroes> OfferHeroes { get; set; }
    }
}
