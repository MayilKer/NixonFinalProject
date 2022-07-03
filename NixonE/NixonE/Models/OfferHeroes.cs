using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class OfferHeroes
    {
        public int Id { get; set; }
        public string ImageWeb { get; set; }
        [NotMapped]
        public IFormFile ImageFileWeb { get; set; }
        public string ImageMob { get; set; }
        [NotMapped]
        public IFormFile ImageFileMob { get; set; }
        public string Name { get; set; }
    }
}
