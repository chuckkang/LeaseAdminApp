using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBConnectionTest.Models;
namespace DBConnectionTest.DataClasses
{
    public class LoadData
    {

        private static LeaseAdminEntities db = new LeaseAdminEntities();

        private static List<Vendor> VendorList = new List<Vendor>();
        private static List<CalendarMonth> CalendarMonthList = new List<CalendarMonth>();
        private static List<CalendarYear> CalendarYearList = new List<CalendarYear>();
        private static List<TenderType> TenderTypeList = new List<TenderType>();
        private static List<BusinessDate> BusinessDateList = new List<BusinessDate>();
        private static List<ExpenseResponsibility> ExpenseResponsibilityList = new List<ExpenseResponsibility>();
        private static List<ExpensesType> ExpenseTypeList = new List<ExpensesType>();
        public static void PopulateLists()
        {
            // this is to be called from the app_start
            VendorList = db.Vendors.OrderBy(v=>v.VendorName).ToList();
            CalendarMonthList = db.CalendarMonths.ToList();
            CalendarYearList = db.CalendarYears.OrderByDescending(y=>y.CalYear).ToList();
            TenderTypeList = db.TenderTypes.OrderBy(t=>t.Tender).ToList();
            BusinessDateList = db.BusinessDates.OrderByDescending(y => y.BusinessDay).ToList();
            ExpenseResponsibilityList = db.ExpenseResponsibilities.OrderBy(t => t.ExpenseResponsibilityType).ToList();
            ExpenseTypeList = db.ExpensesTypes.OrderBy(t => t.ExpenseType).ToList();
        }

        public static List<Vendor> GetVendorList()
        {
            return VendorList;
        }

        public static string GetVendorName(int? id)
        {   if (id==null)
            {
                return null;
            }
            return VendorList.Single(v => v.VendorID == id).VendorName;
        }

        public static List<CalendarMonth> GetCalendarMonthsList()
        {
            return CalendarMonthList;
        }

        public static string GetCalendarMonth(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return CalendarMonthList.Single(v => v.CalendarMonthID == id).CalMonth;
        }
        public static List<CalendarYear> GetCalendarYearList()
        {
            return CalendarYearList;
        }

        public static string GetCalendarYear(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return CalendarYearList.Single(v => v.CalendarYearID == id).CalYear;
        }

        public static List<TenderType> GetTenderTypeList()
        {
            return TenderTypeList;
        }

        public static string GetTenderType(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return TenderTypeList.Single(v => v.TenderTypeID == id).Tender;
        }

        public static List<BusinessDate> GetBusinessDateList()
        {
            return BusinessDateList;
        }


        public static string GetBusinessDate(int? id) 
        {
            if (id == null)
            {
                return null;
            }
            return BusinessDateList.Single(v => v.DateID == id).BusinessDay.ToShortDateString();
        }

        public static List<ExpenseResponsibility> GetExpenseResponsibilityList()
        {
            return ExpenseResponsibilityList;
        }

        public static string GetExpenseResponsibility(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return ExpenseResponsibilityList.Single(v => v.ExpenseResponsibilityID == id).ExpenseResponsibilityType;
        }

        public static List<ExpensesType> GetExpenseTypeList()
        {
            return ExpenseTypeList;
        }

        public static string GetExpenseType(int? id)
        {
            Console.WriteLine(id + "-------------------------");
            if (id == null)
            {
                return null;
            }
            return ExpenseTypeList.SingleOrDefault(v => v.ExpenseTypeID == id).ExpenseType;
        }

        /*
         Select list functions are in this class since it pulls the static data on application start....it's probably better somewhere else.
        */
        public static List<SelectListItem> GetVendorSelect()
        {
            List<SelectListItem> cml = new List<SelectListItem>();
            foreach (var cm in VendorList)
            {
                cml.Add(new SelectListItem { Text = cm.VendorName.ToString(), Value = cm.VendorID.ToString() });
            }
            return cml;
        }
        public static List<SelectListItem> GetCalendarMonthSelect()
        {
            List<SelectListItem> cml = new List<SelectListItem>();
            foreach (var cm in CalendarMonthList)
            {
                cml.Add(new SelectListItem { Text = cm.CalMonth.ToString(), Value = cm.CalendarMonthID.ToString() });
            }
            return cml;
        }
        public static List<SelectListItem> GetCalendarYearSelect()
        {
            List<SelectListItem> cyl = new List<SelectListItem>();
            foreach (var cm in CalendarYearList)
            {
                cyl.Add(new SelectListItem { Text = cm.CalYear.ToString(), Value = cm.CalendarYearID.ToString() });
            }
            return cyl;
        }
        public static List<SelectListItem> GetTenderTypeSelect()
        {
            List<SelectListItem> cyl = new List<SelectListItem>();
            foreach (var cm in TenderTypeList)
            {
                cyl.Add(new SelectListItem { Text = cm.Tender.ToString(), Value = cm.TenderTypeID.ToString() });
            }
            return cyl;
        }
        public static List<SelectListItem> GetBusinessDateSelect()
        {
            List<SelectListItem> bday = new List<SelectListItem>();
            foreach (var day in BusinessDateList)
            {
                bday.Add(new SelectListItem { Text = day.BusinessDay.ToString("MM/dd/yyyy"), Value = day.DateID.ToString() });
            }
            return bday;
        }
        public static List<SelectListItem> GetExpenseResponsibilitySelect(int? id)
        {
            List<SelectListItem> cyl = new List<SelectListItem>();
            if (id == null)
            {
                cyl.Add(new SelectListItem { Text = "Choose Responsiblity", Value = "", Selected = true });
            }
            foreach (var cm in ExpenseResponsibilityList)
            {
               if (id==cm.ExpenseResponsibilityID)
                {
                    cyl.Add(new SelectListItem { Text = cm.ExpenseResponsibilityType.ToString(), Value = cm.ExpenseResponsibilityID.ToString(), Selected=true});
                }
               else
                {
                    cyl.Add(new SelectListItem { Text = cm.ExpenseResponsibilityType.ToString(), Value = cm.ExpenseResponsibilityID.ToString() });
                }
            }
            return cyl;
        }
        public static List<SelectListItem> GetExpenseTypeSelect(int? id)
        {
            List<SelectListItem> cyl = new List<SelectListItem>();
            if (id == null)
            {
                cyl.Add(new SelectListItem { Text = "Choose Expense Type", Value = "", Selected = true });
            }
            foreach (var cm in ExpenseTypeList)
            {
                if (id == cm.ExpenseTypeID)
                {
                    cyl.Add(new SelectListItem { Text = cm.ExpenseType.ToString(), Value = cm.ExpenseTypeID.ToString(), Selected = true });
                }
                else
                {
                    cyl.Add(new SelectListItem { Text = cm.ExpenseType.ToString(), Value = cm.ExpenseTypeID.ToString() });
                }
            }
            return cyl;
        }
    }
}