using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace DBConnectionTest.Models
{
    public static class Print
    {
        public static void Line(object str)
        {
            
            Debug.WriteLine("----------------------Debug----------------------------");
            Debug.WriteLine(str.ToString());
            Debug.WriteLine("----------------------Debug----------------------------");
        }

    }
}