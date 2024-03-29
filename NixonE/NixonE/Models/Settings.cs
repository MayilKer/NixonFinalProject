﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class Settings
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        [NotMapped]
        public IFormFile LogoImg { get; set; }
    }
}
