using System;

namespace Sisacon.Domain
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ExclusionDate { get; set; }
    }
}
