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
        [Display(Name = "Product ID")]
        [Key, ForeignKey("Product")]
        public int ProductID { get; set; }

        [Display(Name ="Testing Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Testing End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public string Dragon { get; set; }

        public string Jaws { get; set; }

        public string Kurzweil { get; set; }

        public string NVDA { get; set; }

        public string Zoomtext { get; set; }

        [Display(Name ="Report Completed")]
        public bool ReportCompleted { get; set; }


        public virtual Product Product { get; set; }
    }
}