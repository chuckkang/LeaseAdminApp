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
using DBConnectionTest.DataClasses;
using System.Collections;
namespace DBConnectionTest.Controllers
{
    public class VendorsController : Controller
    {
        private LeaseAdminEntities db = new LeaseAdminEntities();

        // GET: Vendors
        public ActionResult Index()
        {
            List<Vendor> vendors = db.Vendors.OrderBy(v => v.VendorName).ToList();
            List<VendorModel> vm = new List<VendorModel>();
            foreach (var ven in vendors)
            {
                vm.Add(ven.ReturnModel());
            }
            return View(vm);
        }

        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendors = db.Vendors.Find(id);
            if (vendors == null)
            {
                return HttpNotFound();
            }
            VendorModel vvm = vendors.ReturnModel();
            return View(vvm);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorID,VendorName,Address,City,State,ZipCode,Description,CreaatedAt,ModifiedAt")] VendorModel vendor)
        {
            if (ModelState.IsValid)
            {
                Vendor vendorEntity = new Vendor();
                vendorEntity.UpdateEntityModel(vendor);
                db.Vendors.Add(vendorEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendors = db.Vendors.Find(id);
            VendorModel vendorview = vendors.ReturnModel();
            if (vendors == null)
            {
                return HttpNotFound();
            }
            return View(vendorview);
        }
        
        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorID,VendorName,Address,City,State,ZipCode,Description")] VendorModel vm)
        {
            if (ModelState.IsValid)
            {
                Vendor vendor = db.Vendors.Find(vm.VendorID);
                vendor.UpdateEntityModel(vm);
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Vendor has been updated";
                return RedirectToAction("Index");
            }
            return View(vm);
        }


        public ActionResult Expenses(int? vendorid)
        {
            if (vendorid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // get Vendor information
            // get list of all expenses related to this vendor.
            VendorExpensesViewModel vendorExpenses = new VendorExpensesViewModel();
            Vendor vendor = db.Vendors.Find(vendorid);
            vendorExpenses.Vendor = vendor.ReturnModel();
            if (vendorExpenses.Vendor == null)
            {
                return HttpNotFound();
            }
            vendorExpenses.ExpensesList = ExpensesViewModelCreate(db.Expenses.Where(exp => exp.VendorID == vendorid).OrderByDescending(exp=>exp.ExpenseDateID).ToList());
            foreach (var exp in vendorExpenses.ExpensesList)
            {
                Print.Line(exp.VendorID);
            }

            return View(vendorExpenses);
        }

        private List<ExpenseModel> ExpensesViewModelCreate(List<Expense> expenseList)
        {
            List<ExpenseModel> vmList = new List<ExpenseModel>();

            foreach (var expense in expenseList)
            {
                ExpenseModel vm = new ExpenseModel()
                {
                   ExpenseID = expense.ExpenseID,
                    ExpenseDateID = expense.ExpenseDateID,
                    VendorID = expense.VendorID,
                    InvoiceAmount = expense.InvoiceAmount,
                    CheckNo = expense.CheckNo,
                    ServiceMonthId = expense.ServiceMonthId,
                    ServiceYearId = expense.ServiceYearId,
                    TenantNote = expense.TenantNote,
                    OwnerNote = expense.OwnerNote,
                    InvoiceNo = expense.InvoiceNo,
                    TenderTypeId = expense.TenderTypeId,
                    ExpenseCleared = expense.ExpenseCleared,
                    CreatedAt = expense.CreatedAt,
                    ModifiedAt = expense.ModifiedAt
                };
                vmList.Add(vm);
            }
            return vmList;
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
