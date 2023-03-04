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
                return RedirectToAction("EditProducts", "Admin");
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
                return PartialView();

            var response = await _productService.GetProduct(id);
            if(response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return PartialView(response.Data);
            }

            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(ProductDetailsViewModel vm)
        {

            if (ModelState.IsValid)
            {
                if(vm.Id == 0)
                {
					var response = await _productService.CreateProduct(vm);

					return Json(new { description = response.Description });
				}
                else
                {
					var response = await _productService.Edit(vm);

					return Json(new { description = response.Description });
				}
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
