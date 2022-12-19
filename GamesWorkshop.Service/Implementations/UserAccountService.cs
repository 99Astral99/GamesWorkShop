using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Enums;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.ProfileModels;
using GamesWorkshop.Service.Interfaces;
using GamesWorshop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamesWorkshop.Service.Implementations
{
	public class UserAccountService : IUserAccountService
	{
		private readonly IBaseRepository<UserAccount> _userAccountRepository;
		private readonly IMapper _mapper;

		public UserAccountService(IBaseRepository<UserAccount> userAccountProfileRepository,
			IMapper mapper)
		{
			_userAccountRepository = userAccountProfileRepository;
			_mapper = mapper;
		}

		public async Task<IBaseResponse<UserAccountViewModel>> GetProfile(string userId, string userEmail, string userName)
		{
			try
			{
				var profile = await _userAccountRepository.GetAll().FirstOrDefaultAsync(p => p.UserId.ToString() == userId);

				if (profile == null)
				{
					UserAccount newProfile = new UserAccount()
					{
						UserId = new Guid(userId),
						Address = " ",
						Country = " ",
						Email = userEmail,
						Name = userName,
					};
					await _userAccountRepository.Create(newProfile);

					var vm = _mapper.Map<UserAccountViewModel>(newProfile);

					return new BaseResponse<UserAccountViewModel>()
					{
						StatusCode = StatusCode.OK,
						Data = vm,
					};
				}
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
				var profile = await _userAccountRepository.GetAll().FirstOrDefaultAsync(p => p.UserId == vm.Id);

				if (profile == null)
				{
					return new BaseResponse<UserAccount>()
					{
						Description = "User not found"
					};
				}

				//var data = _mapper.Map<UserAccount>(vm);
				profile.Address = vm.Address;
				profile.Country = vm.Country;
				profile.Age = vm.Age;
				profile.Email = vm.Email;
				profile.Name = vm.UserName;
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
						Email = profile.Email,
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
	}
}

