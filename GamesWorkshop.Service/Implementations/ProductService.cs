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
            try
            {
                var products = await _productRepository.Select();
                if (products.Count() == 0)
                {
                    return new BaseResponse<IEnumerable<Product>>()
                    {
                        Description = "Zero items found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<IEnumerable<Product>>()
                {
                    StatusCode = StatusCode.OK,
                    Data = products
                };

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
            try
            {
                var product = await _productRepository.Get(id);
                if (product == null || product.Id != id)
                {
                    return new BaseResponse<Product>
                    {
                        Description = "Item not found",
                        StatusCode = StatusCode.ProductNotFound
                    };
                }
                return new BaseResponse<Product>
                {
                    Data = product
                };

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
            try
            {
                var product = await _productRepository.GetByName(name);
                if (product == null || product.Name != name)
                {
                    return new BaseResponse<Product>
                    {
                        Description = "Item not found",
                        StatusCode = StatusCode.ProductNotFound
                    };
                }
                return new BaseResponse<Product>
                {
                    Data = product
                };

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
            try
            {
                var products = await _productRepository.GetProductsByCategory(category);
                if (products == null)
                {
                    return new BaseResponse<IEnumerable<Product>>()
                    {
                        Description = "Items not found",
                        StatusCode = StatusCode.ProductNotFound
                    };
                }
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Data = products
                };

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
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductViewModel>()
                {
                    Description = $"[CreateProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return new BaseResponse<ProductViewModel> { };
        }
        public async Task<IBaseResponse<bool>> DeleteProduct(int id)
        {
            try
            {
                var product = await _productRepository.Get(id);
                if (product == null || product.Id != id)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Items not found",
                        StatusCode = StatusCode.ProductNotFound
                    };

                }
                await _productRepository.Delete(product);
                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };

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
        public async Task<IBaseResponse<Product>> Edit(int id, ProductViewModel vm)
        {
            try
            {
                var product = await _productRepository.Get(id);
                if (product == null)
                {
                    return new BaseResponse<Product>()
                    {
                        Description = "Product not found",
                        StatusCode = StatusCode.ProductNotFound
                    };
                }

                product.Name = vm.Name;
                product.Price = vm.Price;
                product.Description = vm.Description;
                product.Amount = vm.Amount;
                //category

                await _productRepository.Update(product);

                return new BaseResponse<Product>()
                {
                    Data = product,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[DeleteProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
