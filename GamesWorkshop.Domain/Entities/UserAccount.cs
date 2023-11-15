using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesWorkshop.Domain.Entities
{
	public class UserAccount
	{
		public Guid Id { get; set; }
		public string? Country { get; set; }
		public string? Address { get; set; }
		public string Email { get; set; }
		public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public int Age { get; set; }

		[ForeignKey("User")]
		public Guid UserId { get; set; }
		public User User { get; set; }
	}
}
