using System.ComponentModel.DataAnnotations;

namespace GamesWorkshop.Domain.View.ContactModels
{
	public class CreateContactViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "The email address is required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }
		[MinLength(5), MaxLength(30)]
		public string Subject { get; set; }
		[MaxLength(150)]
		public string Message { get; set; }
	}
}
