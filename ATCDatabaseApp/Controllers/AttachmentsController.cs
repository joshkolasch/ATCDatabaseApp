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
    public class AttachmentsController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Attachments
        public ActionResult Index()
        {
            var attachments = db.Attachments.Include(a => a.Product);
            attachments = attachments.OrderBy(a => a.Product.ProductName);
            return View(attachments.ToList());
        }

        // GET: Attachments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // GET: Attachments/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName");
            return View();
        }

        // POST: Attachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductID,FileName,FilePath")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                db.Attachments.Add(attachment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", attachment.ProductID);
            return View(attachment);
        }

        // GET: Attachments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", attachment.ProductID);
            return View(attachment);
        }

        // POST: Attachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductID,FileName,FilePath")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attachment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", attachment.ProductID);
            return View(attachment);
        }

        // GET: Attachments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // POST: Attachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attachment attachment = db.Attachments.Find(id);
            db.Attachments.Remove(attachment);
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

        //id is productID
        public ActionResult CreateWizard(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ProductName = product.ProductName;
            //ViewBag.pID = new SelectList(db.Products, "ID", "ProductName", product.ID);
            //ViewBag.ProductName = product.ProductName;
            //ViewBag.ProductID = id;
            //ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", id);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", id);
            //var prod = new List<SelectListItem>();
            //prod.Add(new SelectListItem() { Text = product.ProductName, Value = product.ID.ToString() });
            //ViewBag.prod = new SelectList(prod, "Value", "Text");
            ViewBag.id = id;
            return View();
        }

        //TODO: fix the Viewbag ProductID vs productID [recommend changing ProductID to ProductList and productID to ProductID]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include = "ID,ProductID,FileName,FilePath")] Attachment attachment, int? id)
        {
            ViewBag.pID = new SelectList(db.Products, "ID", "ProductName", attachment.ProductID);
            
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                db.Attachments.Add(attachment);
                db.SaveChanges();
                return RedirectToAction("Details", "Products", new { id = id });
            }

            ViewBag.ProductID = id;
            return View(attachment);
        }
    }
}
