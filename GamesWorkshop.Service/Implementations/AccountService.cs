using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Enums;
using GamesWorkshop.Domain.Helpers;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.UserModels;
using GamesWorkshop.Service.Interfaces;
using GamesWorshop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GamesWorkshop.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public AccountService(IBaseRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IBaseResponse<ClaimsIdentity>> Register(RegisterViewModel vm)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Email == vm.Email);
                if (user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "User with the same credentials already exists",
                    };
                }

                user = _mapper.Map<User>(vm);
                user.Password = HashPasswordHelper.HashPassword(user.Password);
                user.RoleId = 1;

                await _userRepository.Create(user);
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "User created",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<ClaimsIdentity>> Login(LoginViewModel vm)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == vm.Email);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "User not found"
                    };
                }

                if (!BCrypt.Net.BCrypt.Verify(vm.Password, user.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Wrong password"
                    };
                }

                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
            };

            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimTypes.Email, ClaimTypes.Role);
            //ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
