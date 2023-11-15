using GamesWorkshop.Domain.Entities;
using GamesWorshop.DAL.Interfaces;

namespace GamesWorshop.DAL.Repositories
{
    public class UserAccountRepository : IBaseRepository<UserAccount>
    {
        private readonly AppDbContext _dbContext;
        public UserAccountRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(UserAccount entity)
        {
            await _dbContext.Profiles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(UserAccount entity)
        {
            _dbContext.Profiles.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<UserAccount> GetAll()
        {
            return _dbContext.Profiles.AsQueryable();
        }

        public async Task<UserAccount> Update(UserAccount entity)
        {
            _dbContext.Profiles.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
