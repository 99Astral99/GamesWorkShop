namespace GamesWorkshop.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<Order> Orders { get; set; }
    }
}
