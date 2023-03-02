using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Service.Implementations;
using GamesWorkshop.Service.Interfaces;
using GamesWorshop.DAL.Interfaces;
using GamesWorshop.DAL.Repositories;

namespace GamesWorkshop
{
	public static class Initializer
	{
		public static void InitializeRepositories(this IServiceCollection services)
		{
			services.AddScoped<IBaseRepository<Product>, ProductRepository>();
			services.AddScoped<IBaseRepository<Cart>, CartRepository>();
			services.AddScoped<IBaseRepository<Order>, OrderRepository>();
			services.AddScoped<IBaseRepository<User>, UserRepository>();
			services.AddScoped<IBaseRepository<UserAccount>, UserAccountRepository>();
			services.AddScoped<IBaseRepository<Contact>, ContactRepository>();
		}

		public static void InitializeServices(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<ICartService, CartService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IUserAccountService, UserAccountService>();
			services.AddScoped<IContactService, ContactService>();
		}
	}
}
