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
            List<VendorViewModel> vm = new List<VendorViewModel>();
            foreach (var ven in vendors)
            {
                vm.Add(VendorViewModelCreate(ven));
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
            return View(vendors);
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
        public ActionResult Create([Bind(Include = "VendorID,VendorName,Address,City,State,ZipCode,Description")] VendorViewModel vendor)
        {
            if (ModelState.IsValid)
            {
                Vendor newVendor = VendorCreate(vendor, "create");
                db.Vendors.Add(newVendor);
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
            VendorViewModel vendorview = VendorViewModelCreate(vendors);
            if (vendors == null)
            {
                return HttpNotFound();
            }
            return View(vendorview);
        }
        private VendorViewModel VendorViewModelCreate(Vendor vendor)
        {
            VendorViewModel vm = new VendorViewModel()
            {
                VendorID = vendor.VendorID,
                VendorName = vendor.VendorName,
                Address = vendor.Address,
                City = vendor.City,
                State = vendor.State,
                ZipCode = vendor.ZipCode,
                Description = vendor.Description,
                CreatedAt = vendor.CreatedAt,
                ModfiedAt = vendor.ModfiedAt
            };
            return vm;
        }
        
        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorID,VendorName,Address,City,State,ZipCode,Description")] VendorViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Vendor vendor = VendorCreate(vm, "edit");
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        #region
        
        #endregion
        private Vendor VendorCreate(VendorViewModel vm, string action)
        { // this will return a vendor object based off the view model data
            // action is "create", "edit", "display"
            Vendor newVendor = new Vendor();

            newVendor.VendorID = vm.VendorID;
            newVendor.VendorName = vm.VendorName;
            newVendor.Address = vm.Address;
            newVendor.City = vm.City;
            newVendor.State = vm.State;
            newVendor.ZipCode = vm.ZipCode;
            newVendor.Description = vm.Description;
            newVendor.CreatedAt = (action!="create" ? vm.CreatedAt : DateTime.Now);
            newVendor.ModfiedAt = DateTime.Now;

            return newVendor;
        }
        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
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
            return View(vendors);
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
            vendorExpenses.Vendor = VendorViewModelCreate(vendor);
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
        private List<Expense> ExpensesCreate(List<Expense> expenseList, string action)
        { // action ["edit", "create", "display"]
            List<Expense> vmList = new List<Expense>();

            foreach (var expense in expenseList)
            {
                Expense vm = new Expense()
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
                    CreatedAt = (action!="create" ? expense.CreatedAt : System.DateTime.Now),
                    ModifiedAt = DateTime.Now
                };
            }
            return vmList;
        }
        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendors = db.Vendors.Find(id);
            db.Vendors.Remove(vendors);
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
