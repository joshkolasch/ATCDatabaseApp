using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATCDatabaseApp.Models
{
    public class Attachment
    {
        public int ID { get; set; }

        [Display(Name ="Product ID")]
        [ForeignKey("Product")]
        [Required]
        public int ProductID { get; set; }

        [Display(Name ="File Name")]
        public string FileName { get; set; }

        [Display(Name ="File Path")]
        public string FilePath { get; set; }


        public virtual Product Product { get; set; }
    }
}