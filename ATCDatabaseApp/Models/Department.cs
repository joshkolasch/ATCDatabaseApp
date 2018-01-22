using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ATCDatabaseApp.Models
{
    public class Department
    {
        public int ID { get; set; }

        [Display(Name = "Department Name")]
        [Required]
        public string Name { get; set; }
    }
}