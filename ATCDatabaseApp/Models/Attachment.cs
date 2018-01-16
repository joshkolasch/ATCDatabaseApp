using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ATCDatabaseApp.Models
{
    public class Attachment
    {
        public int ID { get; set; }

        [Display(Name ="Product ID")]
        public int ProductID { get; set; }

        [Display(Name ="File Name")]
        public string FileName { get; set; }

        [Display(Name ="File Path")]
        public string FilePath { get; set; }
    }
}