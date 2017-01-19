using AutoMapper;
using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using Sisacon.UI.ViewModels;

namespace Sisacon.UI.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMapping"; }
        }

        protected override void Configure()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<ConfigurationViewModel, Configuration>();
            CreateMap<AddressViewModel, Address>();
            CreateMap<ContactViewModel, Contact>();
            CreateMap<OccupationAreaViewModel, OccupationArea>();
            CreateMap<CompanyViewModel, Company>();
            CreateMap<ClientViewModel, Client>();
            CreateMap<EquipmentViewModel, Equipment>();
            CreateMap<ProviderViewModel, Provider>();
            CreateMap<BankDetailsViewModel, BankDetails>();
        }
    }
}