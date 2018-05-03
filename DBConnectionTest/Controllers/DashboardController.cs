using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBConnectionTest.DataClasses;
using DBConnectionTest.BusinessLogic;
using DBConnectionTest.ViewModels;
using DBConnectionTest.Models;
namespace DBConnectionTest.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index(int monthId=0, int currentYear=0)
        {
            DashboardViewModel dvm = new DashboardViewModel();
            Print.Line($"monthid--{monthId}, currentYear--{currentYear}");
            Alert alert = new Alert(monthId, currentYear);
         
            
            dvm.AlertNav = alert;
            dvm.VendorAlertList = alert.GetMonthlyMissingExpenses();
            Print.Line(dvm.AlertNav.ToString() + "----getAlert");
          
            return View(dvm);
        }
    }
}