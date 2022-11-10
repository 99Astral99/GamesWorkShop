using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Enum;
using GamesWorshop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamesWorshop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Product entity)
        {
            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Product entity)
        {
            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Product> Get(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            return await _dbContext.Products.Where(p => (int)p.Category == Convert.ToInt32(category)).ToListAsync();
        }

        public async Task<Product> GetByName(string name)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<Product>> Select()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> Update(Product entity)
        {
            _dbContext.Products.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Product>> GetTwelveMostRecentProducts()
        {
            return await _dbContext.Products.OrderByDescending(d => d.CreatedDate).Take(12).ToListAsync();
        }
    }
}
