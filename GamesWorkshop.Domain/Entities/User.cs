using Microsoft.AspNetCore.Identity;

namespace GamesWorkshop.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}
