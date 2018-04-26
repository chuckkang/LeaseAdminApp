using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBConnectionTest.Models;
using System.Diagnostics;
using DBConnectionTest.ViewModels;

namespace DBConnectionTest.Controllers
{
    public class TenantsController : Controller
    {
        private LeaseAdminEntities db = new LeaseAdminEntities();

        // GET: Tenants
        public ActionResult Index()
        {
            List<Tenant> info = db.Tenants.Include(e => e.TenantLeaseInfoes).ToList();
            List<TenantModel> tmList = new List<TenantModel>();
            foreach (Tenant entity in info)
            {
                tmList.Add(entity.ReturnModel());
            }
            //this.PrintList(info);
            return View(tmList);
        }

        // GET: Tenants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenants.Find(id);
            
            if (tenant == null)
            {
                return HttpNotFound();
            }
            TenantModel tenantmodel = new TenantModel();
            tenantmodel = tenant.ReturnModel();
            return View(tenantmodel);
        }

        // GET: Tenants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenantID,TenantName,Addl_Address,TenantAddress,TenantCity,TenantState,TenantZip,BillingAddress,BillingAdditional,BillingCity,BillingState,BillingZip,BillingContact,BillingContactPhone,BillingContactEmail,AdditionalInfo")] TenantModel tenantModel)
        {
            if (ModelState.IsValid)
            {
                Tenant tenant = tenantModel.ReturnEntityModel();
                tenant.CreatedAt = DateTime.Now;
                tenant.ModifiedAt = DateTime.Now;
                db.Tenants.Add(tenant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tenantModel);
        }

        // GET: Tenants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            TenantModel tenantmodel = new TenantModel();
            tenantmodel =tenant.ReturnModel();
            return View(tenantmodel);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenantID,TenantName,Addl_Address,TenantAddress,TenantCity,TenantState,TenantZip,BillingAddress,BillingAdditional,BillingCity,BillingState,BillingZip,BillingContact,BillingContactPhone,BillingContactEmail,AdditionalInfo,CreatedAt, ModifiedAt")] TenantModel tenantModel)
        {
            if (ModelState.IsValid)
            {
                //Tenant tenat = db.Tenants.SingleOrDefault(t => t.TenantId == tenantModel.TenantId);
                Tenant updatedTenant = tenantModel.ReturnEntityModel();
                Print.Line(tenantModel.ReturnModelToString());
                updatedTenant.ModifiedAt = DateTime.Now;
                Print.Line(tenantModel.ReturnModelToString());
                db.Entry(updatedTenant).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Tenant was successfully updated.";
                return RedirectToAction("Index");
            }
            return View(tenantModel);
        }

        // GET: Tenants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            TenantModel tm = tenant.ReturnModel();
            return View(tm);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            db.Tenants.Remove(tenant);
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

        public void PrintList(List<Tenant> lst)
        {
            Debug.WriteLine("___________________________________________________________________");
            foreach (var t in lst)
            {
                foreach (var amt in t.TenantLeaseInfoes)
                {
                    Debug.WriteLine(amt.LeaseAmount + "-------------Lease start");
                }
                Debug.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>");
            }
            Debug.WriteLine("___________________________________________________________________");
        }
    }
}
