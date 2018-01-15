using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATCDatabaseApp.Models
{
    public class Accessibility
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public string Dragon { get; set; }

        public string Jaws { get; set; }

        public string Kurzweil { get; set; }

        public string NVDA { get; set; }

        public string Zoomtext { get; set; }
    }
}