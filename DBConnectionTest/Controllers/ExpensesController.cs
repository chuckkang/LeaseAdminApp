using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBConnectionTest.Models;
using DBConnectionTest.ViewModels;

namespace DBConnectionTest.Controllers
{
    public class ExpensesController : Controller
    {
        private LeaseAdminEntities db = new LeaseAdminEntities();

        // GET: Expenses
        public ActionResult Index()
        {
            ExpenseModel vm = new ExpenseModel();
            List<ExpenseModel> model = Expense.ReturnModelList(db.Expenses.OrderByDescending(e => e.ExpenseDateID).ToList());
            return View(model);
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseAndDetailsViewModel expView = new ExpenseAndDetailsViewModel();
            Expense exp = db.Expenses.SingleOrDefault(e => e.ExpenseID == id);
            expView.Expense = exp.ReturnModel;
            

            if (expView.Expense == null)
            {
                return HttpNotFound();
            }
            expView.ExpenseDetailsList = expView.ReturnModelList(db.ExpenseDetails.Where(e => e.ExpenseId == id).ToList());// i doint have access to the interface.
            return View(exp);
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
        public ActionResult Create([Bind(Include = "ExpenseID,ExpenseDateID,VendorID,InvoiceAmount,CheckNo,ServiceMonthId,ServiceYearId,TenantNote,OwnerNote,InvoiceNo,Tender,ExpenseCleared")] ExpenseModel expenses)
        {
            if (ModelState.IsValid)
            {
                Expense expense = db.Expenses.SingleOrDefault(id => id.ExpenseID == expenses.ExpenseID);
                expense = expenses.ReturnEntity;
                expense.CreatedAt = DateTime.Now;
                expense.ModifiedAt = DateTime.Now;
                db.Expenses.Add(expense);
                db.SaveChanges();
                TempData["Message"] = "The expense has been submitted.";
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
            ExpenseAndDetailsViewModel expView = new ExpenseAndDetailsViewModel();
            Expense expense = (db.Expenses.SingleOrDefault(e => e.ExpenseID == id));
            expView.Expense = expense.ReturnModel;
            expView.ExpenseDetailsList = ExpenseDetail.ReturnModelList(db.ExpenseDetails.Where(e => e.ExpenseId == id).ToList());
            Print.Line(expView.Expense.ToString());
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
        public ActionResult Edit([Bind(Include = "ExpenseID,ExpenseDateID,VendorID,InvoiceAmount,CheckNo,ServiceMonthId,ServiceYearId,TenantNote,OwnerNote,InvoiceNo,Tender,ExpenseCleared,CreatedAt,ModifiedAt")] ExpenseModel expenses)
        {
            if (ModelState.IsValid)
            {
                Expense exp = db.Expenses.SingleOrDefault(e => e.ExpenseID == expenses.ExpenseID);
                exp.UpdateEntity(expenses);
                exp.ModifiedAt = DateTime.Now;
                Print.Line(exp.ToString());
                db.Entry(exp).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Expense has been updated.";
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
            ExpenseModel expenseModel = expenses.ReturnModel;
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
