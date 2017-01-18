using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sisacon.UI.ViewModels
{
    public class ProviderViewModel : BaseViewModel
    {
        [MaxLength(10)]
        public string CodProvider { get; set; }
        [Required]
        [MaxLength(14)]
        public string Cnpj { get; set; }
        [Required]
        [MaxLength(50)]
        public string SocialReasonName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FantasyName { get; set; }
        [MaxLength(250)]
        public string Note { get; set; }
        public int? IdAddress { get; set; }
        public int? IdContact { get; set; }
        public int IdUser { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}