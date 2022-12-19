using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.ProfileModels;

namespace GamesWorkshop.Service.Interfaces
{
    public interface IUserAccountService
    {
        Task<IBaseResponse<UserAccountViewModel>> GetProfile(string userId, string userEmail, string userName);
        Task<IBaseResponse<UserLoginInfoViewModel>> GetLogin(string userEmail);
        Task<IBaseResponse<UserAccount>> Save(UserAccountViewModel vm);
    }
}
