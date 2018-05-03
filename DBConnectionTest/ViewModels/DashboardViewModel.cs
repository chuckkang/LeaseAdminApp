using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBConnectionTest.BusinessLogic;

namespace DBConnectionTest.ViewModels
{
    public class DashboardViewModel
    {
        public Alert AlertNav { get; set; } = new Alert();
        public List<int> VendorAlertList { get; set; } = new List<int>();
       
    }
}