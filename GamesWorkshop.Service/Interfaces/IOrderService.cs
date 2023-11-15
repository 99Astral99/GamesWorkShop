using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.OrderModels;

namespace GamesWorkshop.Service.Interfaces
{
	public interface IOrderService
	{
		Task<IBaseResponse<Order>> Create(CreateOrderViewModel vm);
		Task<IBaseResponse<bool>> Delete(int id);
	}
}
