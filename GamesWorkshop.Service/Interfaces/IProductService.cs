using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Responses;
using GamesWorkshop.Domain.View.Product;

namespace GamesWorkshop.Service.Interfaces
{
    public interface IProductService
    {
        Task<IBaseResponse<IEnumerable<Product>>> GetProductsByCategory(int category);
        Task<IBaseResponse<IEnumerable<Product>>> GetProducts();
        Task<IBaseResponse<Product>> GetProduct(int id);
        Task<IBaseResponse<Product>> GetByName(string name);
        Task<IBaseResponse<ProductViewModel>> CreateProduct(ProductViewModel productViewModel);
        Task<IBaseResponse<bool>> DeleteProduct(int id);
        Task<IBaseResponse<Product>> Edit(int id, ProductViewModel vm);
    }
}
