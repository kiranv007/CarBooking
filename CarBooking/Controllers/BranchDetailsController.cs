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
    public class BranchDetailsController : Controller
    {
        private CasestudyEntities db = new CasestudyEntities();

        // GET: BranchDetails
        public ActionResult Index()
        {
            return View(db.BranchDetails.ToList());
        }

        // GET: BranchDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchDetail branchDetail = db.BranchDetails.Find(id);
            if (branchDetail == null)
            {
                return HttpNotFound();
            }
            return View(branchDetail);
        }

        // GET: BranchDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BranchDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BranchID,BranchName,City,Address")] BranchDetail branchDetail)
        {
            if (ModelState.IsValid)
            {
                db.BranchDetails.Add(branchDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(branchDetail);
        }

        // GET: BranchDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchDetail branchDetail = db.BranchDetails.Find(id);
            if (branchDetail == null)
            {
                return HttpNotFound();
            }
            return View(branchDetail);
        }

        // POST: BranchDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BranchID,BranchName,City,Address")] BranchDetail branchDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branchDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branchDetail);
        }

        // GET: BranchDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchDetail branchDetail = db.BranchDetails.Find(id);
            if (branchDetail == null)
            {
                return HttpNotFound();
            }
            return View(branchDetail);
        }

        // POST: BranchDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BranchDetail branchDetail = db.BranchDetails.Find(id);
            db.BranchDetails.Remove(branchDetail);
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
