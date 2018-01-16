using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATCDatabaseApp.Models
{
    public class Accessibility
    {
        [Display(Name ="Product ID")]
        [Key, ForeignKey("Product")]
        public int ProductID { get; set; }

        public string Dragon { get; set; }

        public string Jaws { get; set; }

        public string Kurzweil { get; set; }

        public string NVDA { get; set; }

        public string Zoomtext { get; set; }


        public virtual Product Product { get; set; }
    }
}