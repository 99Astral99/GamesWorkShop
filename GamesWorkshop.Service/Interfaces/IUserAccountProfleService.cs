using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.ProfileModels;

namespace GamesWorkshop.Service.Interfaces
{
    public interface IUserAccountService
    {
        Task<IBaseResponse<UserAccountViewModel>> GetProfile(int userId);
        Task<IBaseResponse<UserAccount>> Save(UserAccountViewModel vm);
    }
}
