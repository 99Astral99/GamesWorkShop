using GamesWorkshop.Domain.Entities;
using GamesWorshop.DAL.Interfaces;

namespace GamesWorshop.DAL.Repositories
{
    public class CartRepository : IBaseRepository<Cart>
    {
        private readonly AppDbContext _dbContext;
        public CartRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Cart entity)
        {
            await _dbContext.Carts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Cart entity)
        {
            _dbContext.Carts.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Cart> GetAll()
        {
            return _dbContext.Carts.AsQueryable();
        }

        public async Task<Cart> Update(Cart entity)
        {
            _dbContext.Carts.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
