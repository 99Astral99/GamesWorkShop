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
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<User, LoginViewModel>();
        }
    }
}
