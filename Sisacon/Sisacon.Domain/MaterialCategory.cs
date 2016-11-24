using System;

namespace Sisacon.Domain
{
    public class MaterialCategory
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? ExclusionDate { get; set; }
        public virtual User User { get; set; }
    }
}
