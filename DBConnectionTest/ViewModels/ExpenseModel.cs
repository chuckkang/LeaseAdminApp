using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DBConnectionTest.Models;
namespace DBConnectionTest.ViewModels
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



        public Expense ReturnEntity
        {
            get {
                Expense expenseModel = new Expense()
                {
                    ExpenseID = this.ExpenseID,
                    ExpenseDateID = this.ExpenseDateID,
                    VendorID = this.VendorID,
                    InvoiceAmount = this.InvoiceAmount,
                    CheckNo = this.CheckNo,
                    ServiceMonthId = this.ServiceMonthId,
                    ServiceYearId = this.ServiceYearId,
                    TenantNote = this.TenantNote,
                    OwnerNote = this.OwnerNote,
                    InvoiceNo = this.InvoiceNo,
                    TenderTypeId = this.TenderTypeId,
                    ExpenseCleared = this.ExpenseCleared,
                    CreatedAt = this.CreatedAt,
                    ModifiedAt = this.ModifiedAt
                };
                return expenseModel;
            }
            set
            {
                this.ExpenseID = ExpenseID;
                this.ExpenseDateID = ExpenseDateID;
                this.VendorID = VendorID;
                this.InvoiceAmount = InvoiceAmount;
                this.CheckNo = CheckNo;
                this.ServiceMonthId = ServiceMonthId;
                this.ServiceYearId = ServiceYearId;
                this.TenantNote = TenantNote;
                this.OwnerNote = OwnerNote;
                this.InvoiceNo = InvoiceNo;
                this.TenderTypeId = TenderTypeId;
                this.ExpenseCleared = ExpenseCleared;
                this.CreatedAt = CreatedAt;
                this.ModifiedAt = ModifiedAt; 
            }

        }
        public List<Expense> ReturnEntityList(List<ExpenseModel> expenseList)
        { // a list<ExpenseModels> must be passed to return a list
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
                    CreatedAt = expense.CreatedAt,
                    ModifiedAt = expense.ModifiedAt
                };
                vmList.Add(vm);
            }
            return vmList;
        }

        override public string ToString()
        {
            return $"ExpenseID: {ExpenseID}, ExpenseDateID: {ExpenseDateID}, VendorID: {VendorID}, InvoiceAmount: {InvoiceAmount}, CheckNo: {CheckNo}, ServiceMonthId: {ServiceMonthId}, ServiceYearId: {ServiceYearId}, TenantNote: {TenantNote}, OwnerNote: {OwnerNote}, InvoiceNo: {InvoiceNo}, TenderTypeId: {TenderTypeId}, ExpenseCleared: {ExpenseCleared}, CreatedAt: {CreatedAt}, ExpenseID: {ModifiedAt} ";
        }
    }

}