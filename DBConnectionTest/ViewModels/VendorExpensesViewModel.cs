using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBConnectionTest.Models;

namespace DBConnectionTest.ViewModels
{
    public class VendorExpensesViewModel
    {

        public VendorModel Vendor { get; set; } = new VendorModel();
        public List<ExpenseModel> ExpensesList { get; set; } = new List<ExpenseModel>();
    }
}