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
    public class AccessibilitiesController : Controller
    {
        private ProductContext db = new ProductContext();

        private SelectList AccessibilityTypes = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem{Text ="Not Tested", Value = "Not Tested" },
                    new SelectListItem{Text ="Accessible", Value = "Accessible" },
                    new SelectListItem{Text ="Not Accessible", Value = "Not Accessible" },
                    new SelectListItem{Text ="Partially Accessible", Value = "Partially Accessible" },
                    new SelectListItem{Text ="N/A", Value = "N/A" }
                }, "Text", "Value", 1);

        // GET: Accessibilities
        public ActionResult Index()
        {
            var accessibilities = db.Accessibilities.Include(a => a.Product);
            accessibilities = accessibilities.OrderBy(a => a.Product.ProductName);
            return View(accessibilities.ToList());
        }

        // GET: Accessibilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessibility accessibility = db.Accessibilities.Find(id);
            if (accessibility == null)
            {
                return HttpNotFound();
            }
            return View(accessibility);
        }

        // GET: Accessibilities/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName");
            return View();
        }

        // POST: Accessibilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Dragon,Jaws,Kurzweil,NVDA,Zoomtext")] Accessibility accessibility)
        {
            if (ModelState.IsValid)
            {
                db.Accessibilities.Add(accessibility);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", accessibility.ProductID);
            return View(accessibility);
        }

        // GET: Accessibilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessibility accessibility = db.Accessibilities.Find(id);
            if (accessibility == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", accessibility.ProductID);
            
            ViewData["AccessibilityTypes"] = AccessibilityTypes;
            return View(accessibility);
        }

        // POST: Accessibilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Dragon,Jaws,Kurzweil,NVDA,Zoomtext")] Accessibility accessibility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessibility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", accessibility.ProductID);
            return View(accessibility);
        }

        // GET: Accessibilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessibility accessibility = db.Accessibilities.Find(id);
            if (accessibility == null)
            {
                return HttpNotFound();
            }
            return View(accessibility);
        }

        // POST: Accessibilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessibility accessibility = db.Accessibilities.Find(id);
            db.Accessibilities.Remove(accessibility);
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

        public ActionResult CreateWizard(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessibility accessibility = db.Accessibilities.Find(id);
            if (accessibility == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", accessibility.ProductID);

            ViewData["AccessibilityTypes"] = AccessibilityTypes;
            return View(accessibility);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include = "ProductID,Dragon,Jaws,Kurzweil,NVDA,Zoomtext")] Accessibility accessibility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessibility).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                //return RedirectToAction("CreateWizard", "Requesters", new { accessibility.ProductID });
                return RedirectToAction("CreateWizard", "ProductRequests", new { id = accessibility.ProductID });
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", accessibility.ProductID);
            return View(accessibility);
        }
    }
}
