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
    public class ISContactsController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: ISContacts
        public ActionResult Index()
        {
            return View(db.ISContacts.ToList());
        }

        // GET: ISContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISContact iSContact = db.ISContacts.Find(id);
            if (iSContact == null)
            {
                return HttpNotFound();
            }
            return View(iSContact);
        }

        // GET: ISContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ISContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,PhoneNumber,Email")] ISContact iSContact)
        {
            if (ModelState.IsValid)
            {
                db.ISContacts.Add(iSContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iSContact);
        }

        // GET: ISContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISContact iSContact = db.ISContacts.Find(id);
            if (iSContact == null)
            {
                return HttpNotFound();
            }
            return View(iSContact);
        }

        // POST: ISContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,PhoneNumber,Email")] ISContact iSContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iSContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iSContact);
        }

        // GET: ISContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISContact iSContact = db.ISContacts.Find(id);
            if (iSContact == null)
            {
                return HttpNotFound();
            }
            return View(iSContact);
        }

        // POST: ISContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ISContact iSContact = db.ISContacts.Find(id);
            db.ISContacts.Remove(iSContact);
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
