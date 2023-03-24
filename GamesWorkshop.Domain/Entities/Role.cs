using Microsoft.AspNetCore.Identity;

namespace GamesWorkshop.Domain.Entities
{
    public class Role : IdentityRole<Guid> 
    {
        public Role(string roleName) : base(roleName)
        {
            Name = roleName;
        }
        public Role()
        {
            
        }
    }
}
