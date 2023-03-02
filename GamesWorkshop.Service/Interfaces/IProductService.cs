using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.ProductModels;

namespace GamesWorkshop.Service.Interfaces
{
    public interface IProductService
    {
        Task<IBaseResponse<IEnumerable<ProductViewModel>>> GetProductsByCategory(string category);
        Task<IBaseResponse<IEnumerable<ProductViewModel>>> GetTwelveMostRecentProducts();
		Task<IBaseResponse<IEnumerable<ProductViewModel>>> GetProducts();
		Task<IBaseResponse<ProductDetailsViewModel>> GetProduct(int id);
        Task<IBaseResponse<ProductDetailsViewModel>> GetByName(string name);
        Task<IBaseResponse<Product>> CreateProduct(ProductDetailsViewModel productViewModel);
        Task<IBaseResponse<bool>> DeleteProduct(int id);
        Task<IBaseResponse<Product>> Edit(ProductDetailsViewModel vm);
    }
}
