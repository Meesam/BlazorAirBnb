using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAirBnb.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username is required.")]
        [DataType(DataType.EmailAddress)]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
