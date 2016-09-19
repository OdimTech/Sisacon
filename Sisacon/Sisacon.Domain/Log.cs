using System;
using static Sisacon.Domain.ValueObjects;

namespace Sisacon.Domain
{
    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public DateTime ErrorDate { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public eErrorGravity eErrorGravity { get; set; }
    }
}
