using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcDemo.Models
{
    public class AddressModel
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Address Line 1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }

        [DisplayName("Address Line 3")]
        public string AddressLine3 { get; set; }

        [DisplayName("Export to PDF")]
        public bool ExportToPDF { get; set; }

        [DisplayName("Save As File")]
        public bool SaveAsFile { get; set; }
    }
}
