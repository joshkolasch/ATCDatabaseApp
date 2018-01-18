using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATCDatabaseApp.DAL;
using ATCDatabaseApp.Models;
using System.Collections.ObjectModel;

namespace ATCDatabaseApp.Controllers
{
    public class HomeController : Controller
    {
        private ProductContext db = new ProductContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult QueryProducts(string sortOrder, string searchString)
        {

            ViewBag.Message = "Products query page";
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            var products = db.Products;
            foreach (var p in products)
            {
                try
                {
                    foreach (var i in db.ISContacts)
                    {
                        if (p.ISContactID == i.ID)
                        {
                            p.ISContact = i;
                            break;
                        }
                    }
                }
                catch { }

                p.Attachments = new Collection<Attachment>();
                foreach (var a in db.Attachments)
                {
                    if (p.ID == a.ProductID)
                    {
                        p.Attachments.Add(a);
                    }
                }
                foreach (var a in db.Accessibilities)
                {
                    if (p.ID == a.ProductID)
                    {
                        p.Accessibility = a;
                        break;
                    }
                }
                foreach (var pr in db.ProductRequests)
                {
                    if(p.ID == pr.ProductID)
                    {
                        p.ProductRequests.Add(pr);
                    }
                }
            }
            var prod = from p in products
                       select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                prod = prod.Where(s => s.ProductName.Contains(searchString));
            }

            if (sortOrder == "name_desc")
            {
                return View(prod.OrderByDescending(p => p.ProductName).ToList());
            }


            return View(prod.ToList());
        }

        public ActionResult QueryRequesters()
        {
            ViewBag.Message = "Query Requesters page";
            var requesters = db.Requesters;
            foreach (var r in requesters)
            {
                var dept = db.Departments.Find(r.DepartmentID);
                r.Department = dept;
            }
            return View(requesters.ToList());
        }
    }
}