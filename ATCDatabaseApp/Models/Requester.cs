using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATCDatabaseApp.Models
{
    public class Requester
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Nullable<int> DepartmentID { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }



        public virtual Department Department { get; set; }
        public virtual ICollection<ProductRequest> ProductRequests { get; set; }
    }
}