using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.OrderModels;
using GamesWorkshop.Service.Interfaces;
using GamesWorshop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamesWorkshop.Service.Implementations
{
    public class CartService : ICartService
    {
        private readonly IBaseRepository<User> _userReposirory;
        private readonly IBaseRepository<Product> _productRepository;

        public CartService(IBaseRepository<User> userRepository, IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _userReposirory = userRepository;
        }
        public async Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName)
        {
            try
            {
                var user = await _userReposirory.GetAll()
                    .Include(x => x.Cart)
                    .ThenInclude(x => x.Orders)
                    .FirstOrDefaultAsync(x => x.UserName.Equals(userName));



                if (user == null)
                {
                    return new BaseResponse<IEnumerable<OrderViewModel>>()
                    {
                        Description = "Usern not found",
                        StatusCode = Domain.Enums.StatusCode.UserNotFound
                    };
                }

                var orders = user.Cart?.Orders;

                var response = from o in orders
                               join p in _productRepository.GetAll() on o.ProductId equals p.Id
                               select new OrderViewModel()
                               {
                                   Id = o.Id,
                                   ProductName = p.Name,
                                   ImageSrc = p.ImageSrc,
                                   Count = o.Count,
                                   Price = p.Price
                               };

                return new BaseResponse<IEnumerable<OrderViewModel>>()
                {
                    Data = response,
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<OrderViewModel>>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternalServerError
                };
            }
        }
    }
}
