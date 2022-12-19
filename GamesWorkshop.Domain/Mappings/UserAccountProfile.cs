using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.View.ProfileModels;

namespace GamesWorkshop.Domain.Mappings
{
    public class UserAccountProfile : Profile
    {
        public UserAccountProfile()
        {
            CreateMap<UserAccount, UserAccountViewModel>();
        }
    }
}
