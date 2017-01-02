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
            Mapper.Initialize(x => x.CreateMap<UserViewModel, User>());
            Mapper.Initialize(x => x.CreateMap<ConfigurationViewModel, Configuration>());
            Mapper.Initialize(x => x.CreateMap<CompanyViewModel, Company>());
            Mapper.Initialize(x => x.CreateMap<AddressViewModel, Address>());
            Mapper.Initialize(x => x.CreateMap<ContactViewModel, Contact>());
            Mapper.Initialize(x => x.CreateMap<OccupationAreaViewModel, OccupationArea>());
        }
    }
}