using Microsoft.AspNetCore.Identity;

namespace GamesWorkshop.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public UserAccount UserAccount { get; set; }
        public Cart Cart { get; set; }
    }
}
