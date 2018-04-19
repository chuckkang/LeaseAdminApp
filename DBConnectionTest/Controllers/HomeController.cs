using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBConnectionTest.Models;
using DBConnectionTest.ViewModels;
using System.Security.Cryptography;
namespace DBConnectionTest.Controllers
{
    public class HomeController : Controller
    {
        private LeaseAdminEntities db = new LeaseAdminEntities();

        public ActionResult Index()
        {
            Session["userid"] = "chuck";
            return RedirectToAction("index", "dashboard");
         
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            ViewBag.Message = TempData["ExtraMessage"];

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {
            if (login == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                // check email address and password.
                User checkuser = db.Users.SingleOrDefault(u => u.UserName == login.Username);
                if (checkuser == null )
                {
                    ViewBag.Message = "No username and password combination found.";
                }
                else
                {

                    //check hased password
                    string pass = BusinessLogic.Authenticate.SHA1(login.Password);
                    var isValid = BusinessLogic.Authenticate.CompareHash(submittedpass: pass, storedpass: checkuser.UserPass);
                    if (isValid)
                    {
                        //Print.Line(isValid + "--" + pass + "----" + checkuser.UserPass);
                        ViewBag.Message = "Logged in";
                        Session["userid"] = checkuser.UserId;
                        return RedirectToAction("", "dashboard");
                    }
                    else
                    {
                        ViewBag.Message = "No username and password combination found.";
                    }
                    
                }
            }
            return View(login);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session["userid"] = null ;

            return View();
        }
    }
}