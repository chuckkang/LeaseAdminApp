//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBConnectionTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Income
    {
        public int IncomeId { get; set; }
        public int BusinessDateId { get; set; }
        public int IncomeTypeId { get; set; }
        public int Tenant { get; set; }
        public Nullable<decimal> LeasePayment { get; set; }
        public Nullable<decimal> TotalPaymentAmount { get; set; }
        public Nullable<decimal> NNNPayment { get; set; }
        public string LeaseMonth { get; set; }
        public string LeaseYear { get; set; }
        public Nullable<decimal> OtherPayment { get; set; }
        public Nullable<int> CheckNo { get; set; }
        public string IncomeNotes { get; set; }
    
        public virtual BusinessDate BusinessDate { get; set; }
        public virtual IncomeType IncomeType { get; set; }
    }
}
