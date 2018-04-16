using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBConnectionTest.Models
{
    public class RegisterViewModel
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required."), MinLength(2, ErrorMessage = "Last name must be more than 2 characters.")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required."), MinLength(2, ErrorMessage = "First name must be more than 2 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a user name.")]
        [MaxLength(25), MinLength(5, ErrorMessage = "User name must be more than 5 characters.")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        [MaxLength(50), MinLength(5, ErrorMessage = "Email must be more than 5 characters.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [MaxLength(25), MinLength(5, ErrorMessage = "Password must be more than 5 characters.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string UserPass { get; set; }

        [NotMapped]
        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage = "please confirm your password")]
        [Compare("UserPass", ErrorMessage = "Password and confirmation password must match.")]
        [DataType(DataType.Password)]
        public string ConfirmPass { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

    }



}