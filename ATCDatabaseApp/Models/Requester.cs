using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ATCDatabaseApp.Models
{
    public class Requester
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public Nullable<int> DepartmentID { get; set; }

        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }



        public virtual Department Department { get; set; }
        public virtual ICollection<ProductRequest> ProductRequests { get; set; }
    }
}