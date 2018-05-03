using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DBConnectionTest.Models;

namespace DBConnectionTest.ViewModels
{
    public class TenantModel
    {

        public int TenantId { get; set; }

        [Required(ErrorMessage = "Tenant Name is required."), MinLength(2, ErrorMessage = "Name must be longer than 2 characters"), MaxLength(50)]
        [Display(Name = "Tenant Name")]
        public string TenantName { get; set; }

        [Display(Name = "Additional Address")]
        public string AddlAddress { get; set; }

        [Required(ErrorMessage = "Address is required."), MinLength(2, ErrorMessage = "Name must be longer than 5 characters"), MaxLength(50)]
        [Display(Name = "Street Address")]
        public string TenantAddress { get; set; }
        [Required(ErrorMessage = "City is required."), MinLength(2, ErrorMessage = "Name must be longer than 2 characters"), MaxLength(50)]
        [Display(Name = "City")]
        public string TenantCity { get; set; }

        [Required(ErrorMessage = "State is required."), MinLength(2, ErrorMessage = "Name must be longer than 2 characters"), MaxLength(50)]
        [Display(Name = "State")]
        public string TenantState { get; set; }

        [Required(ErrorMessage = "ZipCode is required."), MinLength(5, ErrorMessage = "Name must be longer than 5 characters"), MaxLength(50)]
        [Display(Name = "Zip")]
        public string TenantZip { get; set; }

        [MaxLength(50)]
        [Display(Name = "Biiling Address")]
        public string BillingAddress { get; set; }

        [MaxLength(50)]
        [Display(Name = "Additional Address")]
        public string BillingAdditional { get; set; }

        [MaxLength(50)]
        [Display(Name = "Biiling City")]
        public string BillingCity { get; set; }

        [MaxLength(50)]
        [Display(Name = "Biiling State")]
        public string BillingState { get; set; }

        [Display(Name = "Biiling Zip Code")]
        public string BillingZip { get; set; }

        [MaxLength(50)]
        [Display(Name = "Contact Name")]
        public string BillingContact { get; set; }

        [MaxLength(15)]
        [Display(Name = "Contact Phone")]
        [DataType(DataType.PhoneNumber)]
        public string BillingContactPhone { get; set; }

        [MaxLength(100)]
        [Display(Name = "Contact Email")]
        [DataType(DataType.EmailAddress)]
        public string BillingContactEmail { get; set; }

        [MaxLength(100)]
        [Display(Name = "Notes")]
        public string AdditionalInfo { get; set; }
        public System.DateTime CreatedAt { get; set; }

        [Display(Name = "Last Updated")]
        public System.DateTime ModifiedAt { get; set; }

        public Tenant ReturnModel(TenantModel tm)
        {
            Tenant setTenant = new Tenant()
            {
                TenantId = tm.TenantId,
                TenantName = tm.TenantName,
                AddlAddress = tm.AddlAddress,
                TenantAddress = tm.TenantAddress,
                TenantCity = tm.TenantCity,
                TenantState = tm.TenantState,
                TenantZip = tm.TenantZip,
                BillingAddress = tm.BillingAddress,
                BillingAdditional = tm.BillingAdditional,
                BillingCity = tm.BillingCity,
                BillingState = tm.BillingState,
                BillingZip = tm.BillingZip,
                BillingContact = tm.BillingContact,
                BillingContactPhone = tm.BillingContactPhone,
                BillingContactEmail = tm.BillingContactEmail,
                AdditionalInfo = tm.AdditionalInfo,
                CreatedAt = tm.CreatedAt,
                ModifiedAt = tm.ModifiedAt
            };
            return setTenant;
        }
        public Tenant ReturnEntityModel()
        {
            Tenant setTenant = new Tenant()
            {
                TenantId = this.TenantId,
                TenantName = this.TenantName,
                AddlAddress = this.AddlAddress,
                TenantAddress = this.TenantAddress,
                TenantCity = this.TenantCity,
                TenantState = this.TenantState,
                TenantZip = this.TenantZip,
                BillingAddress = this.BillingAddress,
                BillingAdditional = this.BillingAdditional,
                BillingCity = this.BillingCity,
                BillingState = this.BillingState,
                BillingZip = this.BillingZip,
                BillingContact = this.BillingContact,
                BillingContactPhone = this.BillingContactPhone,
                BillingContactEmail = this.BillingContactEmail,
                AdditionalInfo = this.AdditionalInfo,
                CreatedAt = this.CreatedAt,
                ModifiedAt = this.ModifiedAt
            };
            return setTenant;
        }


        public string ReturnModelToString()
        {
            return $"TenantId: {this.TenantId}, TenantName: {this.TenantName}, AddlAddress: {this.AddlAddress}, TenantAddress: {this.TenantAddress}, TenantCity: {this.TenantCity}, TenantState: {this.TenantState}, TenantZip: {this.TenantZip}, BillingAddress: {this.BillingAddress}, BillingAdditional: {this.BillingAdditional}, BillingCity: {this.BillingCity}, BillingState: {this.BillingState}, BillingZip: {this.BillingZip}, BillingContact: {this.BillingContact}, BillingContactPhone: {this.BillingContactPhone}, BillingContactEmail: {this.BillingContactEmail},AdditionalInfo: {this.AdditionalInfo}, CreatedAt: {this.CreatedAt},  ModifiedAt: {this.ModifiedAt} ";
        }

    }

    
}

namespace DBConnectionTest.Models
{
    using DBConnectionTest.ViewModels;

    public partial class Tenant
    {
        //public TenantModel ReturnModel(Tenant tm)
        //{
        //    TenantModel setTenant = new TenantModel()
        //    {
        //        TenantId = tm.TenantId,
        //        TenantName = tm.TenantName,
        //        AddlAddress = tm.AddlAddress,
        //        TenantAddress = tm.TenantAddress,
        //        TenantCity = tm.TenantCity,
        //        TenantState = tm.TenantState,
        //        TenantZip = tm.TenantZip,
        //        BillingAddress = tm.BillingAddress,
        //        BillingAdditional = tm.BillingAdditional,
        //        BillingCity = tm.BillingCity,
        //        BillingState = tm.BillingState,
        //        BillingZip = tm.BillingZip,
        //        BillingContact = tm.BillingContact,
        //        BillingContactPhone = tm.BillingContactPhone,
        //        BillingContactEmail = tm.BillingContactEmail,
        //        AdditionalInfo = tm.AdditionalInfo,
        //        CreatedAt = tm.CreatedAt,
        //        ModifiedAt = tm.ModifiedAt
        //    };
        //    return setTenant;
        //}
        public TenantModel ReturnModel()
        {
            TenantModel setTenant = new TenantModel()
            {
                TenantId = this.TenantId,
                TenantName = this.TenantName,
                AddlAddress = this.AddlAddress,
                TenantAddress = this.TenantAddress,
                TenantCity = this.TenantCity,
                TenantState = this.TenantState,
                TenantZip = this.TenantZip,
                BillingAddress = this.BillingAddress,
                BillingAdditional = this.BillingAdditional,
                BillingCity = this.BillingCity,
                BillingState = this.BillingState,
                BillingZip = this.BillingZip,
                BillingContact = this.BillingContact,
                BillingContactPhone = this.BillingContactPhone,
                BillingContactEmail = this.BillingContactEmail,
                AdditionalInfo = this.AdditionalInfo,
                CreatedAt = this.CreatedAt,
                ModifiedAt = this.ModifiedAt
            };
            return setTenant;
        }
    }
}