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
    public class TenantLeaseInfoesController : Controller
    {
        private LeaseAdminEntities db = new LeaseAdminEntities();

        // GET: TenantLeaseInfoes
        public ActionResult Index()
        {
            List<TenantLeaseInfo> info = db.TenantLeaseInfoes.Include("Tenant").ToList();
            return View(info);
        }

        // GET: TenantLeaseInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenantLeaseInfo tenantLeaseInfo = db.TenantLeaseInfoes.Find(id);
            if (tenantLeaseInfo == null)
            {
                return HttpNotFound();
            }
            return View(tenantLeaseInfo);
        }

        // GET: TenantLeaseInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TenantLeaseInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenantLeaseID,Tenant,LeaseAmount,SquareFootage,ProRataPercentage,PricePerSquareFoot,Notes,NNN,Deposit,LeaseStart,LeaseEnd,RentCommencement,Admin_Fee,ActiveLease")] TenantLeaseInfo tenantLeaseInfo)
        {
            if (ModelState.IsValid)
            {
                db.TenantLeaseInfoes.Add(tenantLeaseInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tenantLeaseInfo);
        }

        // GET: TenantLeaseInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenantLeaseInfo tenantLeaseInfo = db.TenantLeaseInfoes.Find(id);
            if (tenantLeaseInfo == null)
            {
                return HttpNotFound();
            }
            return View(tenantLeaseInfo);
        }

        // POST: TenantLeaseInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenantLeaseID,Tenant,LeaseAmount,SquareFootage,ProRataPercentage,PricePerSquareFoot,Notes,NNN,Deposit,LeaseStart,LeaseEnd,RentCommencement,Admin_Fee,ActiveLease")] TenantLeaseInfo tenantLeaseInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenantLeaseInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenantLeaseInfo);
        }

        // GET: TenantLeaseInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenantLeaseInfo tenantLeaseInfo = db.TenantLeaseInfoes.Find(id);
            if (tenantLeaseInfo == null)
            {
                return HttpNotFound();
            }
            return View(tenantLeaseInfo);
        }

        // POST: TenantLeaseInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TenantLeaseInfo tenantLeaseInfo = db.TenantLeaseInfoes.Find(id);
            db.TenantLeaseInfoes.Remove(tenantLeaseInfo);
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
