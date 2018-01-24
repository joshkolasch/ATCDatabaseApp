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
    public class ProductRequestsController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: ProductRequests
        public ActionResult Index()
        {
            var productRequests = db.ProductRequests.Include(p => p.Product).Include(p => p.Requester);
            productRequests = productRequests.OrderBy(pr => pr.Product.ProductName);
            return View(productRequests.ToList());
        }

        // GET: ProductRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRequest productRequest = db.ProductRequests.Find(id);
            if (productRequest == null)
            {
                return HttpNotFound();
            }
            return View(productRequest);
        }

        // GET: ProductRequests/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName");
            ViewBag.RequesterID = new SelectList(db.Requesters, "ID", "Name");
            return View();
        }

        // POST: ProductRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductID,RequesterID")] ProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                db.ProductRequests.Add(productRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", productRequest.ProductID);
            ViewBag.RequesterID = new SelectList(db.Requesters, "ID", "Name", productRequest.RequesterID);
            return View(productRequest);
        }

        // GET: ProductRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRequest productRequest = db.ProductRequests.Find(id);
            if (productRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", productRequest.ProductID);
            ViewBag.RequesterID = new SelectList(db.Requesters, "ID", "Name", productRequest.RequesterID);
            return View(productRequest);
        }

        // POST: ProductRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductID,RequesterID")] ProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", productRequest.ProductID);
            ViewBag.RequesterID = new SelectList(db.Requesters, "ID", "Name", productRequest.RequesterID);
            return View(productRequest);
        }

        // GET: ProductRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRequest productRequest = db.ProductRequests.Find(id);
            if (productRequest == null)
            {
                return HttpNotFound();
            }
            return View(productRequest);
        }

        // POST: ProductRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductRequest productRequest = db.ProductRequests.Find(id);
            db.ProductRequests.Remove(productRequest);
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

        //this id is the ProductID
        public ActionResult CreateWizard(int? id)
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
            ViewBag.ProductID = id;
            ViewBag.ProductName = product.ProductName;
            ViewBag.RequesterID = new SelectList(db.Requesters, "ID", "Name");
            return View();
            /*ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", productRequest.ProductID);
            ViewBag.RequesterID = new SelectList(db.Requesters, "ID", "Name", productRequest.RequesterID);
            return View(productRequest);*/
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWizard([Bind(Include = "ID,ProductID,RequesterID")] ProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                db.ProductRequests.Add(productRequest);
                db.SaveChanges();
                //TODO: change this redirect to ISContact->CreateWizard
                return RedirectToAction("CreateWizard", "Attachments", new { productID = productRequest.ProductID });
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", productRequest.ProductID);
            ViewBag.RequesterID = new SelectList(db.Requesters, "ID", "Name", productRequest.RequesterID);
            return View(productRequest);
        }

    }
}
