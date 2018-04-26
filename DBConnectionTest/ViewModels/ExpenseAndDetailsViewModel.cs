using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBConnectionTest.Models;
namespace DBConnectionTest.ViewModels
{
    public class ExpenseAndDetailsViewModel
    {
        public ExpenseModel Expense { get; set; } = new ExpenseModel();
        public List<ExpenseDetailModel> ExpenseDetailsList { get; set; } = new List<ExpenseDetailModel>();

        public List<ExpenseDetailModel> ReturnModelList(List<ExpenseDetail> ed)
        {
            List<ExpenseDetailModel> list = new List<ExpenseDetailModel>();
            ExpenseDetailModel edm = new ExpenseDetailModel();
            foreach(ExpenseDetail ex in ed)
            {
                list.Add(edm.ReturnModel(ex) as ExpenseDetailModel);
            }
            return list;
        }
    }
}