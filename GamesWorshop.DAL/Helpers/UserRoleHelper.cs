using GamesWorkshop.Domain.View.UserModels;
using Microsoft.EntityFrameworkCore;

namespace GamesWorshop.DAL.Helpers
{
    public class UserRoleHelper : IUserRoleHeper
    {
        private readonly AppDbContext _dbContext;

        public UserRoleHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserRoleViewModel>> GetUsers()
        {
            var users = await (from user in _dbContext.Users
                               join userRole in _dbContext.UserRoles
                               on user.Id equals userRole.UserId
                               join role in _dbContext.Roles
                               on userRole.RoleId equals role.Id
                               select new UserRoleViewModel()
                               {
                                   UserId = user.Id.ToString(),
                                   Email = user.Email,
                                   UserName = user.UserName,
                                   RoleName = role.Name
                               }).ToListAsync();

            return users;
        }
    }

    public interface IUserRoleHeper
    {
        Task<List<UserRoleViewModel>> GetUsers();
    }
}
