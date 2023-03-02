using GamesWorkshop.Domain.View.ProductModels;
using GamesWorkshop.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetTwelveMostRecentProducts();
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(int id, bool isPartial)
        {
            var response = await _productService.GetProduct(id);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                if (isPartial)
                    return PartialView("ProductModal", response.Data);

                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            var response = await _productService.GetProductsByCategory(category);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productService.DeleteProduct(id);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("Edit", "Admin");
            }

            return RedirectToAction("Error");
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(ProductDetailsViewModel vm)
        {

            if (ModelState.IsValid)
            {
                var response = await _productService.Edit(vm);

                return Json(new { description = response.Description });
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
