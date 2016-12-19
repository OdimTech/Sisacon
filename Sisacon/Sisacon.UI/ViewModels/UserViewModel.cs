using Sisacon.Domain.Enuns;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        [Required]
        public bool Active { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public EmailViewModel Email { get; set; }
        [Required]
        public UserType.eUserType eUserType { get; set; }
        [Required]
        public DateTime? LastLogin { get; set; }
        [Required]
        public bool ShowWellcomeMessage { get; set; }
    }
}