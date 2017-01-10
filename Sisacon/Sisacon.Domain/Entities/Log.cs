using Sisacon.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.Enuns.ErrorGravity;

namespace Sisacon.Domain.Entities
{
    public class Log : BaseEntity
    {
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public eErrorGravity eErrorGravity { get; set; }
    }
}
