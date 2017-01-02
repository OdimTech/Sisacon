using AutoMapper;
using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using Sisacon.UI.ViewModels;

namespace Sisacon.UI.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMapping"; }
        }

        protected override void Configure()
        {
            Mapper.Initialize(x => x.CreateMap<User, UserViewModel>());
            Mapper.Initialize(x => x.CreateMap<Configuration, ConfigurationViewModel>());
            Mapper.Initialize(x => x.CreateMap<Company, CompanyViewModel>());
            Mapper.Initialize(x => x.CreateMap<Address, AddressViewModel>());
            Mapper.Initialize(x => x.CreateMap<Contact, ContactViewModel>());
            Mapper.Initialize(x => x.CreateMap<OccupationArea, OccupationAreaViewModel>());
        }
    }
}