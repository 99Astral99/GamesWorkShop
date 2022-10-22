using GamesWorkshop.Domain.Entities;
using GamesWorshop.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GamesWorshop.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
    }
}
