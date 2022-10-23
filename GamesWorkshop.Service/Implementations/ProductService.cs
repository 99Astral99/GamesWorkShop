using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Enum;
using GamesWorkshop.Domain.Enums;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.Product;
using GamesWorkshop.Service.Interfaces;
using GamesWorshop.DAL.Interfaces;

namespace GamesWorkshop.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
        {
            var baseResponse = new BaseResponse<IEnumerable<Product>>();
            try
            {
                var products = await _productRepository.Select();
                if (products.Count() == 0)
                {
                    baseResponse.Description = "Zero items found";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = products;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"[GetProducts] : {ex.Message}"
                };
            }
        }
        public async Task<IBaseResponse<Product>> GetProduct(int id)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
                var product = await _productRepository.Get(id);
                if (product == null || product.Id != id)
                {
                    baseResponse.Description = "Item not found";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }
                baseResponse.Data = product;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[GetProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<Product>> GetByName(string name)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
                var product = await _productRepository.GetByName(name);
                if (product == null || product.Name != name)
                {
                    baseResponse.Description = "Item not found";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }
                baseResponse.Data = product;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[GetByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<IEnumerable<Product>>> GetProductsByCategory(int category)
        {
            var baseResponse = new BaseResponse<IEnumerable<Product>>();
            try
            {
                var products = await _productRepository.GetProductsByCategory(category);
                if (products == null)
                {
                    baseResponse.Description = "Items not found";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }
                baseResponse.Data = products;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"[GetProductsByCategory] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<ProductViewModel>> CreateProduct(ProductViewModel productViewModel)
        {
            var baseResponse = new BaseResponse<ProductViewModel>();
            try
            {
                var product = new Product()
                {
                    Description = productViewModel.Description,
                    Name = productViewModel.Name,
                    Price = productViewModel.Price,
                    Amount = productViewModel.Amount,
                    Category = (Category)Convert.ToInt32(productViewModel.Category)
                };

                await _productRepository.Create(product);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductViewModel>()
                {
                    Description = $"[CreateProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<bool>> DeleteProduct(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var product = await _productRepository.Get(id);
                if (product == null || product.Id != id)
                {
                    baseResponse.Description = "Items not found";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }
                await _productRepository.Delete(product);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
