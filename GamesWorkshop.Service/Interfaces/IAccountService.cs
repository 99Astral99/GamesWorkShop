using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.UserModels;
using System.Security.Claims;

namespace GamesWorkshop.Service.Interfaces
{
    public interface IAccountService
    {
        Task<IBaseResponse<ClaimsIdentity>> Register(RegisterViewModel vm);
        Task<IBaseResponse<ClaimsIdentity>> Login(LoginViewModel vm);
    }
}
