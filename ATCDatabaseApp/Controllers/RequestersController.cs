using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATCDatabaseApp.DAL;
using ATCDatabaseApp.Models;

namespace ATCDatabaseApp.Controllers
{
    public class RequestersController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Requesters
        public ActionResult Index()
        {
            var requesters = db.Requesters.Include(r => r.Department);
            return View(requesters.ToList());
        }

        // GET: Requesters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requester requester = db.Requesters.Find(id);
            if (requester == null)
            {
                return HttpNotFound();
            }
            return View(requester);
        }

        // GET: Requesters/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
            return View();
        }

        // POST: Requesters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DepartmentID,PhoneNumber,Email")] Requester requester)
        {
            if (ModelState.IsValid)
            {
                db.Requesters.Add(requester);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", requester.DepartmentID);
            return View(requester);
        }

        // GET: Requesters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requester requester = db.Requesters.Find(id);
            if (requester == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", requester.DepartmentID);
            return View(requester);
        }

        // POST: Requesters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DepartmentID,PhoneNumber,Email")] Requester requester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", requester.DepartmentID);
            return View(requester);
        }

        // GET: Requesters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requester requester = db.Requesters.Find(id);
            if (requester == null)
            {
                return HttpNotFound();
            }
            return View(requester);
        }

        // POST: Requesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requester requester = db.Requesters.Find(id);
            db.Requesters.Remove(requester);
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
