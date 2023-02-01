using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Enum;
using GamesWorkshop.Domain.Enums;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.ProductModels;
using GamesWorkshop.Service.Interfaces;
using GamesWorshop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamesWorkshop.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IBaseRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IBaseResponse<IEnumerable<ProductViewModel>>> GetTwelveMostRecentProducts()
        {
            try
            {
                var products = await _productRepository.GetAll().OrderByDescending(d => d.CreatedDate).Take(12).ToListAsync();
                if (products.Count() == 0)
                {
                    return new BaseResponse<IEnumerable<ProductViewModel>>()
                    {
                        Description = "Zero items found",
                        StatusCode = StatusCode.OK
                    };
                }
                var data = _mapper.Map<List<ProductViewModel>>(products);

                return new BaseResponse<IEnumerable<ProductViewModel>>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<ProductViewModel>>()
                {
                    Description = $"[GetTwelveMostRecentProducts] : {ex.Message}"
                };
            }
        }
        public async Task<IBaseResponse<ProductDetailsViewModel>> GetProduct(int id)
        {
            try
            {
                var product = await _productRepository.GetAll().FirstOrDefaultAsync(p => p.Id == id);
                if (product == null || product.Id != id)
                {
                    return new BaseResponse<ProductDetailsViewModel>
                    {
                        Description = "Item not found",
                        StatusCode = StatusCode.ProductNotFound
                    };
                }

                var data = _mapper.Map<ProductDetailsViewModel>(product);

                return new BaseResponse<ProductDetailsViewModel>
                {
                    Data = data,
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductDetailsViewModel>()
                {
                    Description = $"[GetProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<ProductDetailsViewModel>> GetByName(string name)
        {
            try
            {
                var product = await _productRepository.GetAll().FirstOrDefaultAsync(p => p.Name == name);
                if (product == null || product.Name != name)
                {
                    return new BaseResponse<ProductDetailsViewModel>
                    {
                        Description = "Item not found",
                        StatusCode = StatusCode.ProductNotFound
                    };
                }

                var data = _mapper.Map<ProductDetailsViewModel>(product);

                return new BaseResponse<ProductDetailsViewModel>
                {
                    Data = data,
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductDetailsViewModel>()
                {
                    Description = $"[GetByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<IEnumerable<ProductViewModel>>> GetProductsByCategory(string category)
        {
            try
            {
                var products = await _productRepository.GetAll().Where(p => (int)p.Category == Convert.ToInt32(category)).ToListAsync();
                if (products == null)
                {
                    return new BaseResponse<IEnumerable<ProductViewModel>>()
                    {
                        Description = "Items not found",
                        StatusCode = StatusCode.ProductNotFound
                    };
                }

                var data = _mapper.Map<List<ProductViewModel>>(products);
                return new BaseResponse<IEnumerable<ProductViewModel>>()
                {
                    Data = data,
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<ProductViewModel>>()
                {
                    Description = $"[GetProductsByCategory] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<Product>> CreateProduct(ProductDetailsViewModel productViewModel)
        {
            try
            {
                var product = new Product()
                {
                    Description = productViewModel.Description,
                    Name = productViewModel.Name,
                    Price = productViewModel.Price,
                    Amount = productViewModel.Amount,
                    Category = (Category)Convert.ToInt32(productViewModel.Category),
                    ImageSrc = productViewModel.ImageSrc,
                    Image1 = productViewModel.Image1,
                    Image2 = productViewModel.Image2,
                    Image3 = productViewModel.Image3,
                    Image4 = productViewModel.Image4,
                    Image5 = productViewModel.Image5,
                    CreatedDate = productViewModel.CreatedDate,
                };

                await _productRepository.Create(product);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[CreateProduct] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return new BaseResponse<Product> { };
        }
        public async Task<IBaseResponse<bool>> DeleteProduct(int id)
        {
            try
            {
                var product = await _productRepository.GetAll().FirstOrDefaultAsync(p => p.Id == id);
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
        public async Task<IBaseResponse<Product>> Edit(int id, ProductDetailsViewModel vm)
        {
            try
            {
                var product = await _productRepository.GetAll().FirstOrDefaultAsync(p => p.Id == id);
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
                product.Image1 = vm.Image1;
                product.Image2 = vm.Image2;
                product.Image3 = vm.Image3;
                product.Image4 = vm.Image4;
                product.Category = (Category)Convert.ToInt32(vm.Category);
                product.CreatedDate = vm.CreatedDate;

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
