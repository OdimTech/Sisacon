using Sisacon.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Entities
{
    public class Log : BaseEntity
    {
        public string Message { get; set; }
        public string InnerException { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public ErrorGravity.eErrorGravity eErrorGravity { get; set; }
    }
}
