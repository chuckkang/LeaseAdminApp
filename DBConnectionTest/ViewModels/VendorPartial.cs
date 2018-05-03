using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBConnectionTest.ViewModels;
namespace DBConnectionTest.Models
{
    public partial class Vendor
    {

        public VendorModel ReturnModel()
        {
            VendorModel vm = new VendorModel()
            {
                VendorID = this.VendorID,
                VendorName = this.VendorName,
                Address = this.Address,
                City = this.City,
                State = this.State,
                ZipCode = this.ZipCode,
                Description = this.Description,
                CreatedAt = this.CreatedAt,
                ModfiedAt = this.ModfiedAt
            };
        return vm;
        }

        public void UpdateEntityModel(VendorModel vm)
        {
            this.VendorID = vm.VendorID;
            this.VendorName = vm.VendorName;
            this.Address = vm.Address;
            this.City = vm.City;
            this.State = vm.State;
            this.ZipCode = vm.ZipCode;
            this.Description = vm.Description;
            this.CreatedAt = vm.CreatedAt;
            this.ModfiedAt = vm.ModfiedAt;
        }
    }

}