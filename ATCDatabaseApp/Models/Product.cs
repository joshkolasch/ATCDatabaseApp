using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATCDatabaseApp.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Display(Name ="Product Name")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name ="Version #")]
        public string VersionNumber { get; set; }

        [Display(Name ="Serial #")]
        public string SerialNumber { get; set; }

        public string Location { get; set; }

        public string Hardware { get; set; }

        public string Software { get; set; }

        [Display(Name ="Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Renewal Date")]
        [DataType(DataType.Date)]
        public DateTime? RenewalDate { get; set; }

        [Display(Name ="Status")]
        public string ApprovalStatus { get; set; }

        [Display(Name ="ATC Staff")]
        public string ATCStaff { get; set; }

        public Nullable<int> ISContactID { get; set; }

        public string Notes { get; set; }

        [Display(Name ="Vendor Info")]
        public string VendorInfo { get; set; }
        
        [Display(Name ="IS Contact")]
        public virtual ISContact ISContact { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual Accessibility Accessibility { get; set; }
        public virtual ICollection<ProductRequest> ProductRequests { get; set; }

    }
}