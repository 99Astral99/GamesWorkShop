using GamesWorkshop.Domain.Entities;
using GamesWorshop.DAL.Interfaces;

namespace GamesWorshop.DAL.Repositories
{
	public class ContactRepository : IBaseRepository<Contact>
	{
		private readonly AppDbContext _dbContext;
		public ContactRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Create(Contact entity)
		{
			await _dbContext.Contacts.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(Contact entity)
		{
			_dbContext.Contacts.Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public IQueryable<Contact> GetAll()
		{
			return _dbContext.Contacts.AsQueryable();
		}

		public async Task<Contact> Update(Contact entity)
		{
			_dbContext.Contacts.Update(entity);
			await _dbContext.SaveChangesAsync();

			return entity;
		}
	}
}
