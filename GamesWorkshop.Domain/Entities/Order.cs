namespace GamesWorkshop.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public int? CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
