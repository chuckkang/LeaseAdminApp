using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBConnectionTest.Models;

namespace DBConnectionTest.ViewModels
{
    public class VendorExpensesViewModel
    {

        public VendorViewModel Vendor { get; set; } = new VendorViewModel();
        public List<ExpenseModel> ExpensesList { get; set; } = new List<ExpenseModel>();
    }
}