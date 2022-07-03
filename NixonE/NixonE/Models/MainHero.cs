using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class MainHero
    {
        public int Id { get; set; }
        public string HeroImgWeb { get; set; }
        [NotMapped]
        public IFormFile HeroImgWebFile { get; set; }
        public string HeroImgMob { get; set; }
        [NotMapped]
        public IFormFile HeroImgMobFile { get; set; }
        [Required,StringLength(30)]
        public string Title { get; set; }
        [Required,StringLength(100)]
        public string Content { get; set; }
    }
}
