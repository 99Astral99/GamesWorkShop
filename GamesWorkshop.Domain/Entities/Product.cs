using GamesWorkshop.Domain.Enum;

namespace GamesWorkshop.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
        public Category Category { get; set; }
    }
}
