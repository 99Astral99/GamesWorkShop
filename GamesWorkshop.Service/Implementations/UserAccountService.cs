using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Enums;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.ProfileModels;
using GamesWorkshop.Service.Interfaces;
using GamesWorshop.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GamesWorkshop.Service.Implementations
{
	public class UserAccountService : IUserAccountService
	{
		private readonly IBaseRepository<UserAccount> _userAccountRepository;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;

		public UserAccountService(IBaseRepository<UserAccount> userAccountProfileRepository,
			IMapper mapper, UserManager<User> userManager)
		{
			_userAccountRepository = userAccountProfileRepository;
			_mapper = mapper;
			_userManager = userManager;
		}

		public async Task<IBaseResponse<UserAccountViewModel>> GetProfile(string userId, string userEmail)
		{
			try
			{
				var profile = await _userAccountRepository.GetAll().FirstOrDefaultAsync(p => p.UserId.ToString() == userId);
				var data = _mapper.Map<UserAccountViewModel>(profile);

				return new BaseResponse<UserAccountViewModel>()
				{
					StatusCode = StatusCode.OK,
					Data = data
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<UserAccountViewModel>()
				{
					Description = ex.Message,
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<IBaseResponse<UserAccount>> Save(UserAccountViewModel vm)
		{
			try
			{
				var profile = await _userAccountRepository.GetAll().FirstOrDefaultAsync(p => p.UserId.ToString() == vm.UserId.ToString());

				if (profile == null)
				{
					return new BaseResponse<UserAccount>()
					{
						Description = "User not found"
					};
				}

				profile.Address = vm.Address;
				profile.Country = vm.Country;
				profile.Age = vm.Age;
				profile.Email = vm.Email;
				profile.FirstName = vm.FirstName;
				profile.LastName = vm.LastName;
				await _userAccountRepository.Update(profile);

				return new BaseResponse<UserAccount>()
				{
					StatusCode = StatusCode.OK,
					Data = profile,
					Description = "Data updated"
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<UserAccount>()
				{
					Description = ex.Message,
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<IBaseResponse<UserLoginInfoViewModel>> GetLogin(string userEmail)
		{
			try
			{
				var profile = await _userAccountRepository.GetAll().FirstOrDefaultAsync(p => p.Email == userEmail);
				if (profile == null)
				{
					return new BaseResponse<UserLoginInfoViewModel>()
					{
						StatusCode = StatusCode.UserNotFound,
						Description = "User not found"
					};
				}

				return new BaseResponse<UserLoginInfoViewModel>()
				{
					Data = new UserLoginInfoViewModel()
					{
						NewPassword = "",
						OldPassword = "",
					},
					StatusCode = StatusCode.OK,
				};
			}
			catch (Exception ex)
			{

				return new BaseResponse<UserLoginInfoViewModel>()
				{
					Description = ex.Message,
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<IBaseResponse<bool>> ChangePasswordAsync(UserLoginInfoViewModel vm, string userEmail)
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(userEmail);
				if (user == null)
				{
					return new BaseResponse<bool>
					{
						Description = "User does not exist",
						StatusCode = StatusCode.UserNotFound,
					};
				}

				var data = await _userManager.ChangePasswordAsync(user, vm.OldPassword, vm.NewPassword);
				if (data.Succeeded)
				{
					return new BaseResponse<bool>
					{
						Data = true,
						Description = "Password has updated successfully",
						StatusCode = StatusCode.OK,
					};
				}
				else
				{
					return new BaseResponse<bool>
					{
						Description = "Error occured",
						StatusCode = StatusCode.BadRequestError,
					};
				}
			}
			catch (Exception ex)
			{

				return new BaseResponse<bool>()
				{
					Description = ex.Message,
					StatusCode = StatusCode.InternalServerError
				};
			}
		}
	}
}

