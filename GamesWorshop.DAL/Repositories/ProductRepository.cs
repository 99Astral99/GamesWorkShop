﻿using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Enum;
using GamesWorshop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamesWorshop.DAL.Repositories
{
    public class ProductRepository:IBaseRepository<Product>
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Product entity)
        {
            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product entity)
        {
            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Product> GetAll()
        {
            return _dbContext.Products.AsQueryable();
        }

        public async Task<Product> Update(Product entity)
        {
            _dbContext.Products.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
