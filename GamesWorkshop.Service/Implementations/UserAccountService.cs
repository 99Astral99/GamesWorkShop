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

		public async Task<IBaseResponse<UserAccountViewModel>> GetProfile(int UserId)
		{
			try
			{
				var profile = await _userAccountRepository.GetAll().FirstOrDefaultAsync(p => p.UserId == UserId);

				if (profile == null)
				{
					UserAccount newProfile = new UserAccount()
					{
						UserId = UserId,
						Address = " ",
						Country = " ",
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
				var profile = await _userAccountRepository.GetAll().FirstOrDefaultAsync(p => p.UserAccountId == vm.Id);

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
	}
}
