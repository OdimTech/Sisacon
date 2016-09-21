using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Sisacon.Domain.ValueObjects;

namespace Sisacon.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public eUserType eUserType { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? ExclusionDate { get; set; }
        public bool ShowWellcomeMessage { get; set; }
        public virtual Company Company { get; set; }
    }
}