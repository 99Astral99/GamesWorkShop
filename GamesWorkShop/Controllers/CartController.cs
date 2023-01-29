using GamesWorkshop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamesWorkshop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<IActionResult> Detail()
        {
            var response = await _cartService.GetItems(User.Identity.Name);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }

            return RedirectToAction("Index", controllerName: "Product");
        }
    }
}
