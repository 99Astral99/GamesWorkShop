using GamesWorkshop.Domain.Entities;
using GamesWorshop.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamesWorkshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productRepository.Select();


            return View(response);
        }
    }
}
