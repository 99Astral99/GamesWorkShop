using GamesWorkshop;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Mappings;
using GamesWorshop.DAL;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(config =>
{
	config.AddProfile(new ProductProfile());
	config.AddProfile(new UserProfile());
	config.AddProfile(new UserAccountProfile());
	config.AddProfile(new OrderProfile());
});


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
	var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
	options.UseSqlServer(connectionString, m => m.MigrationsAssembly("GamesWorshop.DAL"));
});


builder.Services.AddIdentity<User, Role>(opt =>
{
	opt.User.RequireUniqueEmail = true;
	opt.User.AllowedUserNameCharacters =
	"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";


	opt.Password.RequireDigit = false;
	opt.Password.RequireNonAlphanumeric = false;
	opt.Password.RequireUppercase = true;
	opt.Password.RequiredLength = 8;

	opt.Lockout = new LockoutOptions
	{
		AllowedForNewUsers = true,
		DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
		MaxFailedAccessAttempts = 5
	};
})

				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(opt =>
{
	opt.LoginPath = "/Account/Login";
	opt.LogoutPath = "/Account/Logout";
	opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
	opt.Cookie.SameSite = SameSiteMode.None;
	opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

builder.Services.AddHealthChecks();

builder.Services.AddCors(opt => opt.AddPolicy("AllowGamesWorkshopPolicy", builder => builder
	.WithOrigins("https://www.games-workshop.com/en-FI/Warhammer-40-000")
	.AllowAnyHeader()
	.AllowAnyMethod()
	));


builder.Services.InitializeRepositories();
builder.Services.InitializeServices();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy(new CookiePolicyOptions
{
	MinimumSameSitePolicy = SameSiteMode.None,
	HttpOnly = HttpOnlyPolicy.Always,
	Secure = CookieSecurePolicy.Always,
});
app.UseCors("AllowGamesWorkshopPolicy");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
