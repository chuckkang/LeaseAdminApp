using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBConnectionTest.Models
{
    public class UserMetaData
    {
        [Key]
        public int UserId;

        [StringLength(50)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required."), MinLength(2, ErrorMessage = "Last name must be more than 2 characters.")]
        public string LastName;

        [StringLength(50)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Last name is required."), MinLength(2, ErrorMessage = "First name must be more than 2 characters.")]
        public string FirstName;

        [Required(ErrorMessage = "Please enter a user name.")]
        [MaxLength(25), MinLength(5, ErrorMessage = "User name must be more than 2 characters.")]
        [Display(Name = "Username")]
        public string UserName;

        [Required(ErrorMessage = "Please enter a password.")]
        [MaxLength(25), MinLength(5, ErrorMessage ="Password must be more than 5 characters.")]
        [Display(Name ="Password")]
        public string UserPass;

        [NotMapped]
        [Required(ErrorMessage = "please confirm your password")]
        [Compare("UserPass", ErrorMessage = "Password and confirmation password must match.")]
        public string ConfirmPass { get; set; }

        public DateTime CreatedAt;

        public DateTime ModifiedAt;


    }
}