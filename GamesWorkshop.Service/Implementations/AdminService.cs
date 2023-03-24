using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Enums;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.ProductModels;
using GamesWorkshop.Domain.View.UserModels;
using GamesWorkshop.Service.Interfaces;
using GamesWorshop.DAL.Helpers;
using GamesWorshop.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GamesWorkshop.Service.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IUserRoleHeper _userRoleHelper;

        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public AdminService(IMapper mapper, IBaseRepository<Product> productRepository,
            UserManager<User> userManager, IUserRoleHeper userRoleHelper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _userManager = userManager;
            _userRoleHelper = userRoleHelper;
        }

        public async Task<IBaseResponse<IEnumerable<ProductViewModel>>> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetAll().ToListAsync();
                if (products.Count() == 0)
                {
                    return new BaseResponse<IEnumerable<ProductViewModel>>()
                    {
                        StatusCode = StatusCode.ProductNotFound,
                        Description = "Products not found"
                    };
                }
                var data = _mapper.Map<List<ProductViewModel>>(products);
                return new BaseResponse<IEnumerable<ProductViewModel>>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<ProductViewModel>>
                {
                    Description = $"[DeleteProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<UserRoleViewModel>>> GetUsers()
        {
            try
            {
                //var users = await _userRepository.GetAll().ToListAsync();
                //var users = await _userManager.Users.ToListAsync();
                var users = await _userRoleHelper.GetUsers();

                if (users.Count() == 0)
                {
                    return new BaseResponse<IEnumerable<UserRoleViewModel>>()
                    {
                        StatusCode = StatusCode.InternalServerError,
                        Description = "Zero users found"
                    };
                }
                var data = _mapper.Map<List<UserRoleViewModel>>(users);

                return new BaseResponse<IEnumerable<UserRoleViewModel>>
                {
                    StatusCode = StatusCode.OK,
                    Data = data,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<UserRoleViewModel>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<bool>> EditRole(UserRoleViewModel vm)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(vm.UserId);
                if (user == null)
                {
                    return new BaseResponse<bool>()
                    {
                        StatusCode = StatusCode.InternalServerError,
                        Description = "User not found"
                    };
                }
                var role = await _userManager.GetRolesAsync(user);
                var result = await _userManager.RemoveFromRolesAsync(user, role);
                if (!result.Succeeded)
                {
                    return new BaseResponse<bool>()
                    {
                        StatusCode = StatusCode.InternalServerError,
                        Description = "Operation failed"
                    };
                }

                await _userManager.AddToRoleAsync(user, vm.RoleName);
                return new BaseResponse<bool>
                {
                    Description = "Role has changed",
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = ex.Message
                };
            }
        }
    }
}
