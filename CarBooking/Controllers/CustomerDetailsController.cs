using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarBooking.Models;

namespace CarBooking.Controllers
{
    public class CustomerDetailsController : Controller
    {
        private CasestudyEntities db = new CasestudyEntities();

        // GET: CustomerDetails
        public ActionResult Index()
        {
            return View(db.CustomerDetails.ToList());
        }

        // GET: CustomerDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDetail customerDetail = db.CustomerDetails.Find(id);
            if (customerDetail == null)
            {
                return HttpNotFound();
            }
            return View(customerDetail);
        }

        // GET: CustomerDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Email,Phone,UserName,Password")] CustomerDetail customerDetail)
        {
            if (ModelState.IsValid)
            {
                db.CustomerDetails.Add(customerDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerDetail);
        }

        // GET: CustomerDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDetail customerDetail = db.CustomerDetails.Find(id);
            if (customerDetail == null)
            {
                return HttpNotFound();
            }
            return View(customerDetail);
        }

        // POST: CustomerDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Email,Phone,UserName,Password")] CustomerDetail customerDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerDetail);
        }

        // GET: CustomerDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDetail customerDetail = db.CustomerDetails.Find(id);
            if (customerDetail == null)
            {
                return HttpNotFound();
            }
            return View(customerDetail);
        }

        // POST: CustomerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CustomerDetail customerDetail = db.CustomerDetails.Find(id);
            db.CustomerDetails.Remove(customerDetail);
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
