﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBConnectionTest.Models;
using System.Diagnostics;

namespace DBConnectionTest.Controllers
{
    public class TenantsController : Controller
    {
        private LeaseAdminEntities db = new LeaseAdminEntities();

        // GET: Tenants
        public ActionResult Index()
        {
            List<Tenant> info = db.Tenants.Include(e => e.TenantLeaseInfoes).ToList();
            this.PrintList(info);
            return View(db.Tenants.ToList());
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
            return View(tenant);
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
        public ActionResult Create([Bind(Include = "TenantID,TenantName,Addl_Address,TenantAddress,TenantCity,TenantState,TenantZip,BillingAddress,BillingAdditional,BillingCity,BillingState,BillingZip,BillingContact,BillingContactPhone,BillingContactEmail,AdditionalInfo")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.Tenants.Add(tenant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tenant);
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
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenantID,TenantName,Addl_Address,TenantAddress,TenantCity,TenantState,TenantZip,BillingAddress,BillingAdditional,BillingCity,BillingState,BillingZip,BillingContact,BillingContactPhone,BillingContactEmail,AdditionalInfo")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenant);
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
            return View(tenant);
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
