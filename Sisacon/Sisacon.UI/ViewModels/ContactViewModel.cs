using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public class ContactViewModel
    {
        [MaxLength(10)]
        public string LandLine { get; set; }
        [MaxLength(10)]
        public string CellPhone { get; set; }
        [MaxLength(254)]
        public EmailViewModel Email { get; set; }
        [MaxLength(250)]
        public string UrlSite { get; set; }
    }
}