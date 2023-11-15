using AutoMapper;
using GamesWorkshop.Domain.View.UserModels;
using GamesWorkshop.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesWorkshop.Controllers
{
	public class AccountController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IAccountService _accountService;
		public AccountController(IMapper mapper, IAccountService accountService)
		{
			_mapper = mapper;
			_accountService = accountService;
		}

		[HttpGet]
		public IActionResult Registration() => View();

		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Registration(RegisterViewModel vm)
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}

			var result = await _accountService.RegistrationAsync(vm);

			if (result.StatusCode == Domain.Enums.StatusCode.OK)
			{
				return Json(new { description = result.Description });
			}

			return BadRequest(result.Description);
		}

		[HttpGet]
		public IActionResult Login(string returnUrl)
		{
			if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
			{
				TempData["returnUrl"] = returnUrl;
			}
			else
			{
				TempData["returnUrl"] = Url.Action(nameof(ProductController.Index), "Product");
			}
			return View();
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel vm)
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}
			var returnUrl = TempData["returnUrl"] as string;
			var result = await _accountService.LoginAsync(vm);
			if (result.StatusCode == Domain.Enums.StatusCode.OK)
			{
				if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl) && returnUrl != "/Account/Registration")
				{
					return LocalRedirect(returnUrl);
				}
				else
				{
					return RedirectToAction(nameof(ProductController.Index), "Product");
				}

			}
			else
			{
				return RedirectToAction(nameof(Login));
			}
		}

		[Authorize]
		public async Task<IActionResult> Logout(string returnUrl)
		{
			if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
			{
				TempData["returnUrl"] = returnUrl;
			}
			else
			{
				TempData["returnUrl"] = Url.Action(nameof(Login));
			}

			await _accountService.LogoutAsync();
			return Redirect(returnUrl ?? Url.Action(nameof(Login)));
		}
	}
}
