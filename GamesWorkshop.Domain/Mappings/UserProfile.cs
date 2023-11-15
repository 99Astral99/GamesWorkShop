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

            CreateMap<User, LoginViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<User, UserRoleViewModel>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.Id));
        }
    }
}
