using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATCDatabaseApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ATCDatabaseApp.DAL
{
    public class ProductContext : DbContext
    {

        public ProductContext() : base("ProductContext") { }

        public DbSet<Accessibility> Accessibilities { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ISContact> ISContacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRequest> ProductRequests { get; set; }
        public DbSet<Requester> Requesters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

    }
}