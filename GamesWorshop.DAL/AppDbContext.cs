using GamesWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesWorshop.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
    }
}
