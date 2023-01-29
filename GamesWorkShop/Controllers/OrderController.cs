using GamesWorkshop.Domain.View.OrderModels;
using GamesWorkshop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamesWorkshop.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(int id, int count)
        {
            if (ModelState.IsValid)
            {
                var vm = new CreateOrderViewModel
                {
                    ProductId = id,
                    Login = User.Identity.Name,
                    Count = count,
                    DateCreated = DateTime.Now,
                };
                var response = await _orderService.Create(vm);
                if (response.StatusCode == Domain.Enums.StatusCode.OK)
                {
                    return Json(new { description = response.Description });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            var response = await _orderService.Delete(id);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Detail", "Cart");
            }
            return View("Error", $"{response.Description}");
        }
    }
}
