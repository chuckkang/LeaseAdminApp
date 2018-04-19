using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DBConnectionTest.Models;
namespace DBConnectionTest.ViewModels.Expenses
{
    public class ExpenseModel
    {
        [Key]
        public int ExpenseID { get; set; }

        [Required(ErrorMessage = "Please select a date.")]
        [Display(Name = "Invoice Date")]
        public int ExpenseDateID { get; set; }

        [Required(ErrorMessage = "Please select a vendor.")]
        [Display(Name = "Vendor")]
        public int VendorID { get; set; }

        [Required(ErrorMessage = "Please input an amount for the invoice.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Amount")]
        public Nullable<decimal> InvoiceAmount { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false, NullDisplayText = "")]
        [Display(Name = "CheckNo")]
        public Nullable<int> CheckNo { get; set; }

        [Required(ErrorMessage ="Please select a month and year of service.")]
        [Display(Name = "ServiceData")]
        public int ServiceMonthId { get; set; }
        [Required(ErrorMessage = "Please select the year of service.")]
        public int ServiceYearId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false, NullDisplayText = "")]
        [Display(Name = "Tenant Note")]
        public string TenantNote { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false, NullDisplayText = "")]
        [Display(Name = "Owner Note")]
        public string OwnerNote { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false, NullDisplayText = "")]
        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }

        [Required(ErrorMessage = "Please select tender.")]
        [Display(Name = "TenderType")]
        public int TenderTypeId { get; set; }
        [Display(Name = "Cleared")]
        public bool ExpenseCleared { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime ModifiedAt { get; set; }



        public ExpenseModel ModelToView(Expense expense)
        {
                ExpenseModel expenseModel = new ExpenseModel()
                {
                    ExpenseID = expense.ExpenseID,
                    ExpenseDateID = expense.ExpenseDateID,
                    VendorID = expense.VendorID,
                    InvoiceAmount = expense.InvoiceAmount,
                    CheckNo = expense.CheckNo,
                    ServiceMonthId = expense.ServiceMonthId,
                    ServiceYearId = expense.ServiceYearId,
                    TenantNote = expense.TenantNote,
                    OwnerNote = expense.OwnerNote,
                    InvoiceNo = expense.InvoiceNo,
                    TenderTypeId = expense.TenderTypeId,
                    ExpenseCleared = expense.ExpenseCleared,
                    CreatedAt = expense.CreatedAt,
                    ModifiedAt = expense.ModifiedAt
                };
            return expenseModel;
        }
        public List<ExpenseModel> ModelToView(List<Expense> expenseList)
        {
            List<ExpenseModel> vmList = new List<ExpenseModel>();

            foreach (var expense in expenseList)
            {
                ExpenseModel vm = new ExpenseModel()
                {
                    ExpenseID = expense.ExpenseID,
                    ExpenseDateID = expense.ExpenseDateID,
                    VendorID = expense.VendorID,
                    InvoiceAmount = expense.InvoiceAmount,
                    CheckNo = expense.CheckNo,
                    ServiceMonthId = expense.ServiceMonthId,
                    ServiceYearId = expense.ServiceYearId,
                    TenantNote = expense.TenantNote,
                    OwnerNote = expense.OwnerNote,
                    InvoiceNo = expense.InvoiceNo,
                    TenderTypeId = expense.TenderTypeId,
                    ExpenseCleared = expense.ExpenseCleared,
                    CreatedAt = expense.CreatedAt,
                    ModifiedAt = expense.ModifiedAt
                };
                vmList.Add(vm);
            }
            return vmList;
        }
        public List<Expense> ViewToModel(List<Expense> expenseList, string action)
        { // action ["edit", "create", "display"]
            List<Expense> vmList = new List<Expense>();

            foreach (var expense in expenseList)
            {
                Expense vm = new Expense()
                {
                    ExpenseID = expense.ExpenseID,
                    ExpenseDateID = expense.ExpenseDateID,
                    VendorID = expense.VendorID,
                    InvoiceAmount = expense.InvoiceAmount,
                    CheckNo = expense.CheckNo,
                    ServiceMonthId = expense.ServiceMonthId,
                    ServiceYearId = expense.ServiceYearId,
                    TenantNote = expense.TenantNote,
                    OwnerNote = expense.OwnerNote,
                    InvoiceNo = expense.InvoiceNo,
                    TenderTypeId = expense.TenderTypeId,
                    ExpenseCleared = expense.ExpenseCleared,
                    CreatedAt = (action != "create" ? expense.CreatedAt : System.DateTime.Now),
                    ModifiedAt = DateTime.Now
                };
            }
            return vmList;
        }
    }

}