using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBConnectionTest.Models;
namespace DBConnectionTest.DataClasses
{
    public class LoadData
    {

        private static FresnoLeaseEntities db = new FresnoLeaseEntities();

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
            VendorList = db.Vendors.OrderByDescending(v=>v.VendorName).ToList();
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
    }
}