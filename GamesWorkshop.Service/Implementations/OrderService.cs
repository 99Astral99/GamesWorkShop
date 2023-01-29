using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.OrderModels;
using GamesWorkshop.Service.Interfaces;
using GamesWorshop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamesWorkshop.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<User> _userReposirory;
        private readonly IBaseRepository<Order> _orderRepository;

        public OrderService(IBaseRepository<User> userRepository, IBaseRepository<Order> orderRepository)
        {
            _userReposirory = userRepository;
            _orderRepository = orderRepository;
        }
        public async Task<IBaseResponse<Order>> Create(CreateOrderViewModel vm)
        {
            try
            {
                var user = await _userReposirory.GetAll()
                    .Include(x => x.Cart)
                    .FirstOrDefaultAsync(x => x.UserName == vm.Login);

                if (user == null)
                {
                    return new BaseResponse<Order>()
                    {
                        Description = "User not found",
                        StatusCode = Domain.Enums.StatusCode.UserNotFound
                    };
                }

                var order = new Order()
                {
                    DateCreated = vm.DateCreated,
                    ProductId = vm.ProductId,
                    CartId = user.Cart.Id,
                    Count = vm.Count
                };

                await _orderRepository.Create(order);

                return new BaseResponse<Order>()
                {
                    Description = "Product added to cart",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>
                {
                    Description = $"[Create]: {ex.Message}",
                    StatusCode = Domain.Enums.StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            try
            {
                var order = _orderRepository.GetAll()
                    .Select(x => x.Cart.Orders.FirstOrDefault(x => x.Id == id))
                    .FirstOrDefault(x => x.Id == id);

                if (order == null)
                {
                    return new BaseResponse<bool>
                    {
                        Description = "Order not found",
                        StatusCode = Domain.Enums.StatusCode.OrderNotFound
                    };
                }

                await _orderRepository.Delete(order);
                return new BaseResponse<bool>
                {
                    StatusCode = Domain.Enums.StatusCode.OK,
                    Description = "Order deleted"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    StatusCode = Domain.Enums.StatusCode.InternalServerError,
                    Description = $"[Delete]: {ex.Message}"
                };
            }
        }
    }
}
