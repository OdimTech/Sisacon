using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Sisacon.Domain.Enuns.FormatImg;
using static Sisacon.Domain.Enuns.PersonType;

namespace Sisacon.UI.ViewModels
{
    public class CompanyViewModel
    {
        public ePersonType ePersonType { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public string SocialReasonName { get; set; }
        public string UrlPathLogo { get; set; }
        public eFormatImg eFormatImg { get; set; }

        //RELATIONSHIP
        public virtual OccupationAreaViewModel OccupationArea { get; set; }
        public virtual AddressViewModel Address { get; set; }
        public virtual ContactViewModel Contact { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}