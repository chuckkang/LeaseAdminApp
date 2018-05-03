using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DBConnectionTest.Models;
namespace DBConnectionTest.ViewModels
{
    public class VendorModel
    {
        [Key]
        public int VendorID { get; set; }

        [Required(ErrorMessage = "Please enter a Vendor Name"), MinLength(2, ErrorMessage = "Name must be longer than 2 characters"), MaxLength(50, ErrorMessage = "Name nust be shorter than 50 characters")]
        [Display(Name = "Vendor Name:")]
        public string VendorName { get; set; }

        [MaxLength(50, ErrorMessage = "Name nust be shorter than 50 characters")]
        [Display(Name = "Address:")]
        public string Address { get; set; }

        [MaxLength(100, ErrorMessage = "Name nust be shorter than 100 characters")]
        [Display(Name = "City:")]
        public string City { get; set; }

        [MaxLength(50, ErrorMessage = "Name nust be shorter than 50 characters")]
        [Display(Name = "State:")]
        public string State { get; set; }

        [MaxLength(20, ErrorMessage = "Name nust be shorter than 20 characters")]
        [Display(Name = "Zip Code:")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter the description.")]
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> ModfiedAt { get; set; }
    }
}