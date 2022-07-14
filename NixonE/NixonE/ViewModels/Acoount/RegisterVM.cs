using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NixonE.ViewModels.Acoount
{
    public class RegisterVM
    {
        [StringLength(255),Required]
        public string FirstName { get; set; }
        [StringLength(255), Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress,Required]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
