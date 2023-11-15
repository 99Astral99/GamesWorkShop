using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Enums;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.UserModels;
using GamesWorkshop.Service.Interfaces;
using GamesWorshop.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GamesWorkshop.Service.Implementations
{
	public class AccountService : IAccountService
	{
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;
		private readonly IBaseRepository<Cart> _cartRepository;
		private readonly IBaseRepository<UserAccount> _userAccountRepository;
		private readonly IMapper _mapper;

		public AccountService(IMapper mapper,
			UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
			IBaseRepository<Cart> cartRepository, IBaseRepository<UserAccount> userAccountRepository)
		{
			_mapper = mapper;
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_cartRepository = cartRepository;
			_userAccountRepository = userAccountRepository;
		}

		public async Task<IBaseResponse<bool>> LoginAsync(LoginViewModel vm)
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(vm.Email);
				if (user == null)
				{
					return new BaseResponse<bool>
					{
						StatusCode = StatusCode.UserNotFound,
						Description = "Invalid credentials"
					};
				}

				//matching password
				if (!await _userManager.CheckPasswordAsync(user, vm.Password))
				{
					return new BaseResponse<bool>
					{
						StatusCode = StatusCode.UserNotFound,
						Description = "Invalid credentials"
					};
				}

				var signInResult = await _signInManager.PasswordSignInAsync(user, vm.Password, false, true);
				if (signInResult.Succeeded)
				{
					var userRoles = await _userManager.GetRolesAsync(user);
					var authClaims = new List<Claim>
					{
						new Claim(ClaimTypes.Email, user.Email),
						new Claim(ClaimTypes.Name, user.UserName),
						new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
					};
					foreach (var userRole in userRoles)
					{
						authClaims.Add(new Claim(ClaimTypes.Role, userRole));
					}

					return new BaseResponse<bool>()
					{
						StatusCode = StatusCode.OK,
						Description = "Logged in successfully",
					};
				}
				else if (signInResult.IsLockedOut)
				{
					return new BaseResponse<bool>()
					{
						StatusCode = StatusCode.OK,
						Description = "User locked out",
					};
				}
				else
				{
					return new BaseResponse<bool>()
					{
						StatusCode = StatusCode.InternalServerError,
						Description = "Error on logging in",
					};
				}
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>()
				{
					StatusCode = StatusCode.InternalServerError,
					Description = ex.Message,
				};
			}
		}

		public async Task<IBaseResponse<bool>> RegistrationAsync(RegisterViewModel vm)
		{
			try
			{
				var userExists = await _userManager.FindByEmailAsync(vm.Email);
				if (userExists != null)
				{
					return new BaseResponse<bool>
					{
						StatusCode = StatusCode.BadRequestError,
						Description = "User already exists"
					};
				}

				vm.Role = "User";
				var user = _mapper.Map<User>(vm);
				user.SecurityStamp = Guid.NewGuid().ToString();
				user.EmailConfirmed = true;
				user.PhoneNumberConfirmed = true;

				var data = await _userManager.CreateAsync(user, vm.Password);

				if (!data.Succeeded)
				{
					return new BaseResponse<bool>()
					{
						StatusCode = StatusCode.InternalServerError,
						Description = "User creation failed"
					};
				}

				//role management
				if (!await _roleManager.RoleExistsAsync(vm.Role))
					await _roleManager.CreateAsync(new Role(vm.Role));

				if (await _roleManager.RoleExistsAsync(vm.Role))
				{
					await _userManager.AddToRoleAsync(user, vm.Role);
				}


				var cart = new Cart() { UserId = user.Id };
				await _cartRepository.Create(cart);

				var profile = new UserAccount()
				{
					UserId = user.Id,
					Email = user.Email,
				};
				await _userAccountRepository.Create(profile);

				return new BaseResponse<bool>
				{
					StatusCode = StatusCode.OK,
					Description = "User has registered successfully"
				};
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

		public async Task LogoutAsync()
		{
			await _signInManager.SignOutAsync();
		}
	}
}
