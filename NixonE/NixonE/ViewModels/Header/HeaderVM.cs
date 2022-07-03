using NixonE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.ViewModels.Header
{
    public class HeaderVM
    {
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Style> styles { get; set; }
        public IEnumerable<Use> uses { get; set; }
        public IEnumerable<Tag> tags { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}