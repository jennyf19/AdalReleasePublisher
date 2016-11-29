using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AdalReleasePublisher.dll.Entities
{
    public class Request
    {
        public string ProductList { get; set; }

        public string VersionNumber { get; set; }

        [DataType(DataType.MultilineText)]
        public string ReleaseNotes { get; set; }

        public DateTime DateTime { get; set; }
    }
}
