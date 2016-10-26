using System;
using static Sisacon.Domain.ValueObjects;

namespace Sisacon.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public ePersonType ePersonType { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Rg { get; set; }
        public string ClientName { get; set; }
        public DateTime? Birthday { get; set; }
        public eSex eSex { get; set; }
        public string FantasyName { get; set; }
        public string SocialReasonName { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual User User { get; set; }
        public bool SendAutomaticMsg { get; set; }
        public bool AddBirthdayToCalendar { get; set; }
        public string Note { get; set; }
        public DateTime? ExclusionDate { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
