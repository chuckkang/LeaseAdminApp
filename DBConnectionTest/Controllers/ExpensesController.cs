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
            ExpenseModel newExpense = new ExpenseModel();
            return View(newExpense);
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseID,ExpenseDateID,VendorID,InvoiceAmount,CheckNo,ServiceMonthId,ServiceYearId,TenantNote,OwnerNote,InvoiceNo,TenderTypeId,ExpenseCleared")] ExpenseModel expenses)
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
            //ExpenseAndDetailsViewModel expView = new ExpenseAndDetailsViewModel();
            // add the details view model when ready. Just single line items right now.
            Expense expense = (db.Expenses.SingleOrDefault(e => e.ExpenseID == id));
            //expView.ExpenseDetailsList = ExpenseDetail.ReturnModelList(db.ExpenseDetails.Where(e => e.ExpenseId == id).ToList());
            Print.Line(expense.ToString());
            if (expense == null)
            {
                return HttpNotFound();
            }
            ExpenseModel expView = expense.ReturnModel;

            return View(expView);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseID,ExpenseDateID,VendorID,InvoiceAmount,CheckNo,ServiceMonthId,ServiceYearId,TenantNote,OwnerNote,InvoiceNo,TenderTypeId,ExpenseCleared,CreatedAt,ModifiedAt")] ExpenseModel expenses)
        {
            if (ModelState.IsValid)
            {
                Expense exp = db.Expenses.SingleOrDefault(e => e.ExpenseID == expenses.ExpenseID);
                exp.UpdateEntityFromModel(expenses);
                //exp.ModifiedAt = DateTime.Now;
                Print.Line(exp.ToString());
                db.Entry(exp).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Expense has been updated.";
                return RedirectToAction("Index");
            }
            return View(expenses);
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
            return View(expenseModel);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expenses = db.Expenses.Find(id);
            // remove the line items from expense details.;
            IEnumerable<ExpenseDetail> explist = db.ExpenseDetails.Where(e => e.ExpenseId == id);
            foreach (ExpenseDetail ed in explist)
            {
                db.ExpenseDetails.Remove(ed);
            }
            
            db.Expenses.Remove(expenses);
            TempData["Message"] = "Expense has been deleted";
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
