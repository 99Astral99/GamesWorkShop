using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.ProfileModels;
using GamesWorkshop.Domain.View.UserModels;
using System.Security.Claims;

namespace GamesWorkshop.Service.Interfaces
{
    public interface IAccountService
    {
        //Task<IBaseResponse<ClaimsIdentity>> Register(RegisterViewModel vm);
        //Task<IBaseResponse<ClaimsIdentity>> Login(LoginViewModel vm);
        //Task<IBaseResponse<bool>> ChangePassword(UserLoginInfoViewModel vm);

        //Новые таски

        Task<IBaseResponse<bool>> LoginAsync(LoginViewModel vm);
        Task<IBaseResponse<bool>> RegistrationAsync(RegisterViewModel vm);
        Task LogoutAsync(); 
    }
}
