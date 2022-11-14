using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.UserModels;
using System.Security.Claims;

namespace GamesWorkshop.Service.Interfaces
{
    public interface IAccountService
    {
        public Task<IBaseResponse<ClaimsIdentity>> Register(RegisterViewModel vm);
        public Task<IBaseResponse<ClaimsIdentity>> Login(LoginViewModel vm);
    }
}
