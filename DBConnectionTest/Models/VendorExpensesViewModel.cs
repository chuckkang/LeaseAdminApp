using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBConnectionTest.Models
{
    public class VendorExpensesViewModel
    {

        public Vendor Vendor { get; set; } = new Vendor();
        public List<Expense> ExpensesList { get; set; } = new List<Expense>();
    }
}