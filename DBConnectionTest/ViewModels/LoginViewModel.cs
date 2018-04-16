using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DBConnectionTest.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a user name.")]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}