using GamesWorkshop.Domain.View.UserModels;
using GamesWorkshop.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesWorkshop.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly IAdminService _adminService;
		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		[HttpGet]
		public async Task<IActionResult> EditProducts()
		{
			var response = await _adminService.GetProducts();

			if (response.StatusCode == Domain.Enums.StatusCode.OK)
			{
				return View(response.Data);
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> EditUsers()
		{
			var response = await _adminService.GetUsers();
			if (response.StatusCode == Domain.Enums.StatusCode.OK)
			{
				return View(response.Data);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> EditUsers(UserRoleViewModel vm)
		{
			var response = await _adminService.EditRole(vm);

			if (response.StatusCode == Domain.Enums.StatusCode.OK)
			{
				return Json(new { description = response.Description });
			}
			return View();
		}
	}
}
