using Sisacon.Domain.Enuns;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public bool Active { get; set; }
        public string Password { get; set; }
        public String Email { get; set; }
        public UserType.eUserType eUserType { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool ShowWellcomeMessage { get; set; }
    }
}