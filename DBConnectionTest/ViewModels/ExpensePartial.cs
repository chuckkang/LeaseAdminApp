using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBConnectionTest.ViewModels;

namespace DBConnectionTest.Models
{
    
    public partial class Expense
    {
        /// <summary>
        /// Returns new ExpenseModel from ExpenseEntity
        /// </summary>
        public ExpenseModel ReturnModel
        {
            get
            { 
                ExpenseModel em = new ExpenseModel()
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
                return em;
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

        public static List<ExpenseModel> ReturnModelList(List<Expense> expenseList)
        {
            List<ExpenseModel> exm = new List<ExpenseModel>();
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
                exm.Add(vm);
            }
            return exm;
        }
        public void UpdateEntityFromModel(ExpenseModel expense)
        {
            this.ExpenseID = expense.ExpenseID;
            this.ExpenseDateID = expense.ExpenseDateID;
            this.VendorID = expense.VendorID;
            this.InvoiceAmount = expense.InvoiceAmount;
            this.CheckNo = expense.CheckNo;
            this.ServiceMonthId = expense.ServiceMonthId;
            this.ServiceYearId = expense.ServiceYearId;
            this.TenantNote = expense.TenantNote;
            this.OwnerNote = expense.OwnerNote;
            this.InvoiceNo = expense.InvoiceNo;
            this.TenderTypeId = expense.TenderTypeId;
            this.ExpenseCleared = expense.ExpenseCleared;
            this.CreatedAt = expense.CreatedAt;
            this.ModifiedAt = DateTime.Now;
        }
        public override string ToString()
        {
            return $"ExpenseID: {ExpenseID}, ExpenseDateID: {ExpenseDateID}, VendorID: {VendorID}, InvoiceAmount: {InvoiceAmount}, CheckNo: {CheckNo}, ServiceMonthId: {ServiceMonthId}, ServiceYearId: {ServiceYearId}, TenantNote: {TenantNote}, OwnerNote: {OwnerNote}, InvoiceNo: {InvoiceNo}, TenderTypeId: {TenderTypeId}, ExpenseCleared: {ExpenseCleared}, CreatedAt: {CreatedAt}, ModifiedAt: {ModifiedAt} ";
        }
    }

    public partial class ExpenseDetail
    {
        public ExpenseDetailModel ReturnModel()
        {
            ExpenseDetailModel exd = new ExpenseDetailModel()
            {
                ExpenseDetailsId = this.ExpenseDetailsId,
                ExpenseId = this.ExpenseId,
                ExpenseResponsibilityId = this.ExpenseResponsibilityId,
                ExpenseTypeId = this.ExpenseTypeId,
                Details = this.Details,
                Amount = this.Amount,
                Notes = this.Notes,
                CreatedAt = this.CreatedAt,
                ModifiedAt = this.ModifiedAt
            };
            return exd;
        }

        public static List<ExpenseDetailModel> ReturnModelList(List<ExpenseDetail> ed)
        { // a list<ExpenseModels> must be passed to return a list
            List<ExpenseDetailModel> vmList = new List<ExpenseDetailModel>();

            foreach (var ex in ed)
            {
                ExpenseDetailModel vm = new ExpenseDetailModel()
                {
                    ExpenseDetailsId = ex.ExpenseDetailsId,
                    ExpenseId = ex.ExpenseId,
                    ExpenseResponsibilityId = ex.ExpenseResponsibilityId,
                    ExpenseTypeId = ex.ExpenseTypeId,
                    Details = ex.Details,
                    Amount = ex.Amount,
                    Notes = ex.Notes,
                    CreatedAt = ex.CreatedAt,
                    ModifiedAt = ex.ModifiedAt
                };
                vmList.Add(vm);
            }
            return vmList;
        }
    }

}