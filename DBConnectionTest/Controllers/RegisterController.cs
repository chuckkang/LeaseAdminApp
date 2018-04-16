using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DBConnectionTest.Models;

namespace DBConnectionTest.Controllers
{
    public class RegisterController : Controller
    {
        private LeaseAdminEntities db = new LeaseAdminEntities();

        // GET: Register
        public ActionResult Index()
        {
            RegisterViewModel newuser = new RegisterViewModel();

            return View(newuser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterViewModel newuser)
        {
            if (newuser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                User newaccount = new User()
                {
                    FirstName = newuser.FirstName,
                    LastName = newuser.LastName,
                    Email = newuser.Email,
                    UserName = newuser.UserName,
                    UserPass = newuser.UserPass,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now
                };


                List<User> checkEmail = db.Users.Where(e => e.Email == newaccount.Email).ToList();
                if (checkEmail.Count < 1)
                {
                    // no duplicate email
                    string pass = BusinessLogic.Authenticate.SHA1(newaccount.UserPass);
                    newaccount.UserPass = pass;
                    db.Users.Add(newaccount);
                    db.SaveChanges();
                    TempData["ExtraMessage"] = "Your account has been created.";
                    return RedirectToAction("login", "home");
                }
                else
                {
                    TempData["DuplicateEmail"] = "Duplicate email exists.  Please choose another.";
                }
            }
            return View(newuser);
        }

        // GET: Register/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,UserName,UserPass,CreatedAt,ModifiedAt")] User user)
        {

            return View(user);
        }

        // GET: Register/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,UserName,UserPass,CreatedAt,ModifiedAt")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Register/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
