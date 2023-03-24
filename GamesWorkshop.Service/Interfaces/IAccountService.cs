using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.UserModels;

namespace GamesWorkshop.Service.Interfaces
{
	public interface IAccountService
	{
		Task<IBaseResponse<bool>> LoginAsync(LoginViewModel vm);
		Task<IBaseResponse<bool>> RegistrationAsync(RegisterViewModel vm);
		Task LogoutAsync();
	}
}
