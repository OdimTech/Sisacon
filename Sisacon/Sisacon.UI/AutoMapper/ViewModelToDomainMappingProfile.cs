using AutoMapper;
using Sisacon.Domain.Entities;
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
        }
    }
}