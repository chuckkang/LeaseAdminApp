using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DBConnectionTest.Models;

namespace DBConnectionTest.ViewModels
{
    public class ExpenseDetailModel
    {


        [Key]
        public int ExpenseDetailsId { get; set; }

        public int ExpenseId { get; set; }


        [Required(ErrorMessage = "Please select responsibility.")]
        [Display(Name = "Type")]
        public int ExpenseResponsibilityId { get; set; }

        [Required(ErrorMessage = "Type of Expense is required.")]
        [Display(Name ="Type")]
        public int ExpenseTypeId { get; set; }

        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Charge is required.")]
        [Display(Name = "Charge Fee")]
        public Nullable<decimal> Amount { get; set; }

        public string Notes { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }

        public object ReturnModel(object obj)
        {
            ExpenseDetail ex = obj as ExpenseDetail;

            ExpenseDetailModel edm = new ExpenseDetailModel()
            {
                ExpenseDetailsId = ex.ExpenseDetailsId,
                ExpenseId = ex.ExpenseId,
                ExpenseResponsibilityId = ex.ExpenseResponsibilityId,
                ExpenseTypeId = ex.ExpenseTypeId,
                Details = ex.Details,
                Amount = ex.Amount,
                Notes = ex.Notes ,
                CreatedAt = ex.CreatedAt,
                ModifiedAt = ex.ModifiedAt
            };
            
            return edm;
        }

        public object ReturnEntityModel(object obj)
        {
            ExpenseDetail ex = obj as ExpenseDetail;
            ExpenseDetail edm = new ExpenseDetail()
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

            return edm;
        }

    }
}