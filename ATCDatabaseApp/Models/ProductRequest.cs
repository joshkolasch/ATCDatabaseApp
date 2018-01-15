using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATCDatabaseApp.Models
{
    public class ProductRequest
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int RequesterID { get; set; }



        public virtual Product Product { get; set; }
        public virtual Requester Requester { get; set; }
    }
}