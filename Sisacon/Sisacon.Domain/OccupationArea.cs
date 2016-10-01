using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain
{
    public class OccupationArea
    {
        public int Id { get; set; }
        public string Descrption { get; set; }
        public Company Company { get; set; }
    }
}
