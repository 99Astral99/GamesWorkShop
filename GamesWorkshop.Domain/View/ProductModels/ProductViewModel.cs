using GamesWorkshop.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace GamesWorkshop.Domain.View.ProductModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ImageSrc { get; set; }
		public string? Category { get; set; }
		public string? Description { get; set; }
		public string? Features { get; set; }

    }
}
