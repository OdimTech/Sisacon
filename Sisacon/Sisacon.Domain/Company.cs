using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.ValueObjects;

namespace Sisacon.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public ePersonType ePersonType { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public string SocialReasonName { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
        public string UrlPathLogo { get; set; }
    }
}
