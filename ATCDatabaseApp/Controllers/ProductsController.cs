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
    public class ProductsController : Controller
    {
        private ProductContext db = new ProductContext();

        private SelectList hardwareSoftwareValues = new SelectList(
            new List<SelectListItem>
            {
                new SelectListItem { Text= "Yes", Value = "Yes",},
                new SelectListItem{ Text= "No", Value = "No"}
            }, "Text", "Value", 1);

        private SelectList statusValues = new SelectList(
            new List<SelectListItem>
            {
                new SelectListItem { Text= "Not Approved", Value = "Not Approved",},
                new SelectListItem{ Text= "Approved", Value = "Approved"},
                new SelectListItem{ Text= "In Progress", Value = "In Progress" }
            }, "Text", "Value", 1);

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Accessibility).Include(p => p.ISContact);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            //ViewBag.ID = new SelectList(db.Accessibilities, "ProductID", "Dragon");
            ViewBag.ISContactID = new SelectList(db.ISContacts, "ID", "Name");
            ViewData["hardwareSoftwareDropdown"] = hardwareSoftwareValues;
            ViewData["approvalStatusDropdown"] = statusValues;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,VersionNumber,SerialNumber,Location,Hardware,Software,PurchaseDate,RenewalDate,ApprovalStatus,ATCStaff,ISContactID,Notes,VendorInfo")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ID = new SelectList(db.Accessibilities, "ProductID", "Dragon", product.ID);
            ViewBag.ISContactID = new SelectList(db.ISContacts, "ID", "Name", product.ISContactID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ID = new SelectList(db.Accessibilities, "ProductID", "Dragon", product.ID);
            ViewBag.ISContactID = new SelectList(db.ISContacts, "ID", "Name", product.ISContactID);
            ViewData["hardwareSoftwareDropdown"] = hardwareSoftwareValues;
            ViewData["approvalStatusDropdown"] = statusValues;
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,VersionNumber,SerialNumber,Location,Hardware,Software,PurchaseDate,RenewalDate,ApprovalStatus,ATCStaff,ISContactID,Notes,VendorInfo")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ID = new SelectList(db.Accessibilities, "ProductID", "Dragon", product.ID);
            ViewBag.ISContactID = new SelectList(db.ISContacts, "ID", "Name", product.ISContactID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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

        public ActionResult CreateWizard()
        {
            //ViewBag.ID = new SelectList(db.Accessibilities, "ProductID", "Dragon");
            ViewBag.ISContactID = new SelectList(db.ISContacts, "ID", "Name");
            ViewData["hardwareSoftwareDropdown"] = hardwareSoftwareValues;
            ViewData["approvalStatusDropdown"] = statusValues;
            
            return View();
        }

        public ActionResult EditWizard(int? id)
        {
            //ViewBag.ID = new SelectList(db.Accessibilities, "ProductID", "Dragon");
            ViewBag.ISContactID = new SelectList(db.ISContacts, "ID", "Name");
            ViewData["hardwareSoftwareDropdown"] = hardwareSoftwareValues;
            ViewData["approvalStatusDropdown"] = statusValues;
            if (id != null)
            {
                var product = db.Products.Find(id);
                if (product != null)
                {
                    return View(product);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWizard([Bind(Include = "ID,ProductName,VersionNumber,SerialNumber,Location,Hardware,Software,PurchaseDate,RenewalDate,ApprovalStatus,ATCStaff,ISContactID,Notes,VendorInfo")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CreateWizard", "Accessibilities", new { id = product.ID });
            }
            ViewBag.ISContactID = new SelectList(db.ISContacts, "ID", "Name", product.ISContactID);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include = "ID,ProductName,VersionNumber,SerialNumber,Location,Hardware,Software,PurchaseDate,RenewalDate,ApprovalStatus,ATCStaff,ISContactID,Notes,VendorInfo")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();

                //Create an accessibility row for this new product with 'Not Tested' as the default values
                Accessibility accessibility = new Accessibility { ProductID = product.ID, Dragon = "Not Tested", Jaws = "Not Tested", Kurzweil = "Not Tested", NVDA = "Not Tested", Zoomtext = "Not Tested" };
                db.Accessibilities.Add(accessibility);
                db.SaveChanges();

                return RedirectToAction("CreateWizard", "Accessibilities", new { id = accessibility.ProductID });
            }
            

            //ViewBag.ID = new SelectList(db.Accessibilities, "ProductID", "Dragon", product.ID);
            ViewBag.ISContactID = new SelectList(db.ISContacts, "ID", "Name", product.ISContactID);
            return View(product);
        }
    }
}
