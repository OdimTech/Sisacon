using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain
{
    public class Contact
    {
        public int Id { get; set; }
        public string LandLine { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string UrlSite { get; set; }
    }
}
