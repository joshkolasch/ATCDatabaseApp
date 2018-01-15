using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ATCDatabaseApp.Models;

namespace ATCDatabaseApp.DAL
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            var isContacts = new List<ISContact>
            {
                new ISContact{ID=1, Name="Joe Smish", Email="jsmish@cbc.com", PhoneNumber="555-1111"},
                new ISContact{ID=2, Name="Amy May", Email="amay@cbc.com", PhoneNumber="555-1112"},
                new ISContact{ID=3, Name="Bruno Blitz", Email="bblitz@cbc.com", PhoneNumber="555-1113"}
            };

            isContacts.ForEach(i => context.ISContacts.Add(i));
            context.SaveChanges();


            var products = new List<Product>
            {
                new Product{ID=1, ProductName="CBC Email", Location="cbcEmail.com", Hardware="No", Software="Yes", PurchaseDate=DateTime.Parse("01/01/2016"), RenewalDate=DateTime.Parse("01/01/2017"), ActiveStatus="Active", ATCStaff="Foust One", ISContactID=1, Notes="This has been fully tested", VendorInfo="Contact: James 444-444-9999"},
                new Product{ID=2, ProductName="CBC Eye Tracker", Location="EyeTracker.com", Hardware="Yes", Software="Yes", PurchaseDate=DateTime.Parse("01/01/2016"), RenewalDate=DateTime.Parse("01/01/2017"), ActiveStatus="InActive", ATCStaff="Debrah Two", ISContactID=1, Notes="Bad product. Replaced.", VendorInfo="Contact: Gorge 444-444-9998"},
                new Product{ID=3, ProductName="Vending Machine", Location="Soda.com", Hardware="Yes", Software="Yes", PurchaseDate=DateTime.Parse("01/01/2016"), RenewalDate=DateTime.Parse("01/01/2017"), ActiveStatus="Active", ATCStaff="Pete Three", ISContactID=3, Notes="", VendorInfo="Contact: Fred 444-444-9997. Tech guy: Arnold 444-444-9996"}
            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            var accessibilities = new List<Accessibility>
            {
                new Accessibility{ID=1, ProductID=1, Dragon="Yes", Jaws="Yes", Kurzweil="Yes", NVDA="Yes", Zoomtext="Yes" },
                new Accessibility{ID=2, ProductID=2, Dragon="No", Jaws="Yes", Kurzweil="Buggy", NVDA="Yes", Zoomtext="Not Tested" },
                new Accessibility{ID=3, ProductID=3, Dragon="Not Tested", Jaws="Yes", Kurzweil="Not Applicable", NVDA="Yes", Zoomtext="No" }
            };

            accessibilities.ForEach(a => context.Accessibilities.Add(a));
            context.SaveChanges();


            var attachments = new List<Attachment>
            {
                new Attachment{ID=1, ProductID=1, FileName="Test.docx", FilePath="C:\\User\\Greg"},
                new Attachment{ID=2, ProductID=3, FileName="Test.docx", FilePath="C:\\User\\Sam"},
                new Attachment{ID=3, ProductID=1, FileName="Test.docx", FilePath="C:\\User\\Jess"}
            };

            attachments.ForEach(a => context.Attachments.Add(a));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department{ID=1, Name="Math"},
                new Department{ID=2, Name="Art"},
                new Department{ID=3, Name="English"},
                new Department{ID=4, Name="Science"}
            };

            departments.ForEach(d => context.Departments.Add(d));
            context.SaveChanges();

            var requesters = new List<Requester>
            {
                new Requester{ID=1, Name= "Helga Flowty", DepartmentID=1, PhoneNumber="555-4444", Email="hflowty@cbc.com"},
                new Requester{ID=2, Name= "Gerald Reach", DepartmentID=1, PhoneNumber="555-4443", Email="greach@cbc.com"},
                new Requester{ID=3, Name= "Arthur Blast", DepartmentID=1, PhoneNumber="555-4442", Email="ablast@cbc.com"}
            };

            requesters.ForEach(r => context.Requesters.Add(r));
            context.SaveChanges();
            

            var productRequests = new List<ProductRequest>
            {
                new ProductRequest{ID=1, ProductID=1, RequesterID=2},
                new ProductRequest{ID=2, ProductID=2, RequesterID=2},
                new ProductRequest{ID=3, ProductID=3, RequesterID=3}
            };

            productRequests.ForEach(pr => context.ProductRequests.Add(pr));
            context.SaveChanges();

            
        }
    }
}