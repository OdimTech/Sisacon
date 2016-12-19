using System;

namespace Sisacon.UI.ViewModels
{
    public abstract class BaseViewModel
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? ExclusionDate { get; set; }
    }
}