using System;

namespace Sisacon.Domain
{
    public class Provider
    {
        public int Id { get; set; }
        public string CodProvider { get; set; }
        public string Cnpj { get; set; }
        public string SocialReasonName { get; set; }
        public string FantasyName { get; set; }
        public string Note { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual User User { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? ExclusionDate { get; set; }
    }
}
