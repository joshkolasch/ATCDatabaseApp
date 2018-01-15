using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATCDatabaseApp.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string ProductName { get; set; }

        public string Location { get; set; }

        public string Hardware { get; set; }

        public string Software { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime RenewalDate { get; set; }

        public string ActiveStatus { get; set; }

        public string ATCStaff { get; set; }

        public Nullable<int> ISContactID { get; set; }

        public string Notes { get; set; }

        public string VendorInfo { get; set; }
        
        public virtual ISContact ISContact { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual Accessibility Accessibility { get; set; }

    }
}