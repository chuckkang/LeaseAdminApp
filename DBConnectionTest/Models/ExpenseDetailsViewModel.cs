using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBConnectionTest.Models
{
    public class ExpenseDetailsViewModel
    {
        public Expense Expense { get; set; } = new Expense();
        public List<ExpenseDetail> ExpenseDetailsList { get; set; } = new List<ExpenseDetail>();

    }
}