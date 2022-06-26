using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.Models
{
    public class Banner : BaseEntity
    {
        [StringLength(100)]
        public string Content { get; set; }
    }
}
