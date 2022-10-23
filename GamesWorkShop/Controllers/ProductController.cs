using GamesWorkshop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamesWorkshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productService.GetProducts();


            return View(response.Data);
        }
    }
}
