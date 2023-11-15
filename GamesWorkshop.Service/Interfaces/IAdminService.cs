using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.ProductModels;
using GamesWorkshop.Domain.View.UserModels;

namespace GamesWorkshop.Service.Interfaces
{
    public interface IAdminService
    {
        Task<IBaseResponse<IEnumerable<ProductViewModel>>> GetProducts();
        Task<IBaseResponse<IEnumerable<UserRoleViewModel>>> GetUsers();
        Task<IBaseResponse<bool>> EditRole(UserRoleViewModel vm);
    }
}
