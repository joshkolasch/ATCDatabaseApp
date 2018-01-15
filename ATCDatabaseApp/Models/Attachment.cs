using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATCDatabaseApp.Models
{
    public class Attachment
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }
    }
}