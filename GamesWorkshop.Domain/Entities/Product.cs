using GamesWorkshop.Domain.Enum;

namespace GamesWorkshop.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Features { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ImageSrc { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public Category? Category { get; set; }
    }
}
