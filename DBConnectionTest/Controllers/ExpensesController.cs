using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBConnectionTest.Models;

namespace DBConnectionTest.Controllers
{
    public class ExpensesController : Controller
    {
        private LeaseAdminEntities db = new LeaseAdminEntities();

        // GET: Expenses
        public ActionResult Index()
        {
            
            return View(db.Expenses.OrderByDescending(e=>e.ExpenseDateID).ToList());
        }

        public bool CheckSession()
        {
            bool isValid = (Session["username"] != null ? false : true);
            return ValidateRequest;
        }
        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseDetailsViewModel expView = new ExpenseDetailsViewModel();
            expView.Expense = db.Expenses.SingleOrDefault(e => e.ExpenseID == id);
            expView.ExpenseDetailsList = db.ExpenseDetails.Where(e => e.ExpenseId == id).ToList();

            if (expView.Expense == null)
            {
                return HttpNotFound();
            }
            return View(expView);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseID,ExpenseDateID,VendorID,InvoiceAmount,CheckNo,ServiceMonthId,ServiceYearId,TenantNote,OwnerNote,InvoiceNo,Tender,ExpenseCleared")] Expense expenses)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expenses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expenses);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseDetailsViewModel expView = new ExpenseDetailsViewModel();
            expView.Expense = db.Expenses.SingleOrDefault(e => e.ExpenseID == id);
            expView.ExpenseDetailsList = db.ExpenseDetails.Where(e => e.ExpenseId == id).ToList();

            if (expView.Expense == null)
            {
                return HttpNotFound();
            }
            return View(expView);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseID,ExpenseDateID,VendorID,InvoiceAmount,CheckNo,ServiceMonthId,ServiceYearId,TenantNote,OwnerNote,InvoiceNo,Tender,ExpenseCleared")] Expense expenses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenses);
        }

        [Route("expenses/update/{id}/{id2}")]
        public ActionResult Update(string id, string id2)
        {
            ViewBag.expensesid = Request.Form.AllKeys; // This returns a list of alll items in teh form.
            ViewBag.id = id;
            ViewBag.id2 = id2;
            //ViewBag.expensesdetailsid = expensesdetailsid;
            return View("Test");
        }
        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expenses = db.Expenses.Find(id);
            if (expenses == null)
            {
                return HttpNotFound();
            }
            return View(expenses);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expenses = db.Expenses.Find(id);
            db.Expenses.Remove(expenses);
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
