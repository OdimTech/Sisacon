using System;

namespace Sisacon.Domain
{
    public class Equipment
    {
        public int Id { get; set; }
        public string CodEquipment { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Desc { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public decimal Valor { get; set; }
        public int LifeSpan { get; set; }
        public DateTime? ExcluisionDate { get; set; }
        public virtual User User { get; set; }
    }
}
