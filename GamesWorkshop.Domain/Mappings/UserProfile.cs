using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.View.UserModels;

namespace GamesWorkshop.Domain.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email));
                //.ForMember(x => x.NormalizedUserName, opt => opt.MapFrom(x => x.UserName.ToUpper()))
                //.ForMember(x => x.NormalizedEmail, opt => opt.MapFrom(x => x.Email.ToUpper()));

            CreateMap<User, LoginViewModel>();
        }
    }
}
