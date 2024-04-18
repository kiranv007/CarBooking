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
    public class CustomerLoginsController : Controller
    {
        private CasestudyEntities db = new CasestudyEntities();

        // GET: CustomerLogins
        public ActionResult Index()
        {
            var customerLogins = db.CustomerLogins.Include(c => c.CustomerDetail);
            return View(customerLogins.ToList());
        }

        // GET: CustomerLogins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLogin customerLogin = db.CustomerLogins.Find(id);
            if (customerLogin == null)
            {
                return HttpNotFound();
            }
            return View(customerLogin);
        }

        // GET: CustomerLogins/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.CustomerDetails, "UserName", "FirstName");
            return View();
        }

        // POST: CustomerLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password")] CustomerLogin customerLogin)
        {
            if (ModelState.IsValid)
            {
                db.CustomerLogins.Add(customerLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.CustomerDetails, "UserName", "FirstName", customerLogin.Username);
            return View(customerLogin);
        }

        // GET: CustomerLogins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLogin customerLogin = db.CustomerLogins.Find(id);
            if (customerLogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.CustomerDetails, "UserName", "FirstName", customerLogin.Username);
            return View(customerLogin);
        }

        // POST: CustomerLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password")] CustomerLogin customerLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.CustomerDetails, "UserName", "FirstName", customerLogin.Username);
            return View(customerLogin);
        }

        // GET: CustomerLogins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLogin customerLogin = db.CustomerLogins.Find(id);
            if (customerLogin == null)
            {
                return HttpNotFound();
            }
            return View(customerLogin);
        }

        // POST: CustomerLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CustomerLogin customerLogin = db.CustomerLogins.Find(id);
            db.CustomerLogins.Remove(customerLogin);
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
