using GamesWorkshop.Domain.Entities;
using GamesWorshop.DAL.Configurations;
using GamesWorshop.DAL.EntityTypeConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamesWorshop.DAL
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
			builder.ApplyConfiguration(new OrderConfiguration());
			builder.ApplyConfiguration(new CartConfiguration());
			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new UserAccountConfiguration());
			builder.ApplyConfiguration(new RoleConfiguration());

			//Seeding the relation between our user and role to AspNetUserRoles table
			builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("EC274526-D90E-4ECD-BD85-CD84ED7BB0B1"),
                    UserId = new Guid("480A013F-9EB1-4890-B543-3FD416466804"),
                });

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("FB53FCFE-3B74-4F77-8B9E-E543A38E1BC6"),
                    UserId = new Guid("EC274526-D90E-4ECD-BD85-CD84ED7AE0E9"),
                });

            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<UserAccount> Profiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
