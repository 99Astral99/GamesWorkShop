using GamesWorkshop.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesWorkshop.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly IProductService _productService;

		public AdminController(IProductService productService)
		{
			_productService = productService;
		}
		public async Task<IActionResult> EditProducts()
		{
			var response = await _productService.GetProducts();

			if (response.StatusCode == Domain.Enums.StatusCode.OK)
			{
				return View(response.Data);
			}

			return View();
		}
	}
}
