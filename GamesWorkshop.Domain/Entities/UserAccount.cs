using System.ComponentModel.DataAnnotations.Schema;

namespace GamesWorkshop.Domain.Entities
{
	public class UserAccount
	{
		public int UserAccountId { get; set; }
		public string Country { get; set; }
		public string Address { get; set; }
		//make short
		public int Age { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }
		public User User { get; set; }
	}
}
