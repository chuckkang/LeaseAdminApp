using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBConnectionTest.Models;
namespace DBConnectionTest.DataClasses
{
    public class Alerts
    {
        private LeaseAdminEntities db = new LeaseAdminEntities();

        /// <summary>
        /// GetListOfCompletedExpenses - Gets list of completed expenses that required every month.  Based on ExpenseAlerts list.
        /// currentMonth and CurrentYear parameters are based on id's in the database.
        /// requires: CalYear as an id from db
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Expense> GetListOfCompletedExpenses(int currentMonth=0, int currentYear=0)
        {
            currentMonth = (currentMonth == 0 ? DateTime.Now.Month : currentMonth);
            currentYear = (currentYear == 0 ? DateTime.Now.Year : currentYear);
            Print.Line($"{currentMonth}-COMPLETED-{currentYear}");
            int calYearId = db.CalendarYears.SingleOrDefault(bd => bd.CalYear == currentYear).CalendarYearID;
            List<Vendor> vendorList = new List<Vendor>();
            IEnumerable<int> expList = LoadData.GetExpenseAlertList().Select(e => e.VendorId);
            IEnumerable<Expense> exp = db.Expenses.Where(e => expList.Contains(e.VendorID) && (e.ServiceMonthId == currentMonth && e.ServiceYearId == calYearId));
            return exp;
        }

        public List<int> GetListOfIncompleteExpenses(int currentMonthId = 0, int currentYear = 0)
        {// check required expense list against what was completed return list of vendors that still require an expense.
            Print.Line($"{currentMonthId}-incompelte-{currentYear}");
            List<ExpenseAlert> alertlist = LoadData.GetExpenseAlertList();
            List<int> vendorRequiredList = new List<int>();
            currentMonthId = (currentMonthId == 0 ? DateTime.Now.Month : currentMonthId);
            currentYear = (currentYear == 0 ? DateTime.Now.Year : currentYear);
            //Print.Line($"{currentMonthId}-incompelte-{currentYearId}");
            //int calYearId = db.CalendarYears.SingleOrDefault(bd => bd.CalYear == currentYear).CalendarYearID;
            IEnumerable<Expense> completed = GetListOfCompletedExpenses(currentMonthId, currentYear);
            bool blnAdd = false;
            if (completed.Count() > 0)
            {
                foreach (ExpenseAlert alert in alertlist)
                {
                    blnAdd = false;
                    foreach (Expense exp in completed)
                    {

                        if (exp.VendorID == alert.VendorId)
                        {
                            blnAdd = false;
                            break;
                        }
                        else
                        {
                            blnAdd = true;
                        }
                    }
                    if (blnAdd == true)
                    {
                        vendorRequiredList.Add(alert.VendorId);
                    }
                }
            }
            else
            {
                vendorRequiredList = alertlist.Select(v=>v.VendorId).ToList();
                
            }
            //foreach (int e in vendorRequiredList)
            //{
            //    Print.Line(e + "---" + "Vendorid--NOT COMPLETED");
            //}
            return vendorRequiredList;
        }
    }
}