using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ATCDatabaseApp.Models
{
    public class ProductRequest
    {
        public int ID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int RequesterID { get; set; }



        public virtual Product Product { get; set; }
        public virtual Requester Requester { get; set; }
    }
}