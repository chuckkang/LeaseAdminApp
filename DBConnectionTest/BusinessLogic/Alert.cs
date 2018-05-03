using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBConnectionTest.Models;
using DBConnectionTest.DataClasses;
namespace DBConnectionTest.BusinessLogic
{
    public class Alert
    {

        private int currentYear { get; set; }=DateTime.Now.Year; // this is the actual year as int format.  
        private int currentMonthId = 0; // this is current month as int format
        private int previousMonthId = 0;
        private int nextMonthId = 0;
        private string monthName = string.Empty;
        public Alert()
        {
            this.currentMonthId = 0;
            this.previousMonthId = 0;
            this.nextMonthId = 0;
            this.monthName = string.Empty;
        }

        public Alert(int _currentMonthId, int _currentYear) : base()
        {
            currentMonthId = (_currentMonthId >= 1 && _currentMonthId <= 12 ? _currentMonthId : DateTime.Now.Month);
            previousMonthId = (currentMonthId > 1 ? currentMonthId - 1 : 12);
            nextMonthId = (currentMonthId < 12 ? currentMonthId + 1 : 1);
            monthName = LoadData.GetCalendarMonth(currentMonthId);
        }
        /// <summary>
        /// Function calls alerts class which matches expensealert requirements against vendorids that haven't been submitted for the current month
        /// </summary>
        /// <param name="alertList"></param>
        /// <returns></returns>
        /// 
        public int CurrentMonthId    // the Name property
        {
            get
            {
                return currentMonthId;
            }
            set
            {
                this.currentMonthId = (value >= 1 && value <= 12 ? value : DateTime.Now.Month);
                this.previousMonthId = (currentMonthId == 1 ? 12 : currentMonthId - 1);
                this.nextMonthId = (currentMonthId < 12 ? value + 1 : 1);
                this.monthName = LoadData.GetCalendarMonth(currentMonthId);
            }
        }
        public int CurrentYear    // the Name property
        {
            get
            {
                return currentYear;
            }
            set
            {
                this.currentYear = value;
            }
        }
        public int PreviousMonthId    // the Name property
        {
            get
            {
                return previousMonthId;
            }
        }
        public int NextMonthId    // the Name property
        {
            get
            {
                return nextMonthId;
            }
            //set
            //{
            //    this.currentMonthId = (value < 12 ? value-1 : 11);
            //    this.previousMonthId = (value <= 3 ? value - 2 : 1);
            //    this.nextMonthId = (value <= 12 ? value : 12);
            //}
        }

        public string MonthName
        {
            get { return monthName;  }
        }
        public List<int> GetMonthlyMissingExpenses()
            {

                Alerts alerts = new Alerts();
                List<int> expList = alerts.GetListOfIncompleteExpenses(currentMonthId: currentMonthId, currentYear: currentYear);
                return expList;
            }

        public override string ToString()
        {
            return $"CurrentMonthId: {this.currentMonthId},CurrentYearId: {this.currentYear}, PreviousMonthId: {this.previousMonthId},NextMonthId: {this.nextMonthId},";
        }
    }


}