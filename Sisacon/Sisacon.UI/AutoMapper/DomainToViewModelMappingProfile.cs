using AutoMapper;
using Sisacon.Domain.Entities;
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
        }
    }
}