namespace GamesWorkshop.Domain.Entities
{
	public class Contact
	{
		public int Id { get; set; }
		public Guid UserId { get; set; }
		public User User { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
	}
}
