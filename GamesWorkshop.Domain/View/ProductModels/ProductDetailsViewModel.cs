using System.ComponentModel.DataAnnotations;

namespace GamesWorkshop.Domain.View.ProductModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name can contain a maximum of 50 characters")]
        public string Name { get; set; }

        [StringLength(2000, ErrorMessage = "Description can contain a maximum of 2000 characters")]
        public string? Description { get; set; }

        [StringLength(300, ErrorMessage = "Features can contain a maximum of 300 characters")]
        public string? Features { get; set; }

        [Required]
        [Range(1, 300, ErrorMessage = "Price must be between 1 and 300")]
        public double Price { get; set; }

        [Required]
        [Range(1, 300, ErrorMessage = "Amount must be between 1 and 300")]
        public int Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ImageSrc { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? Image5 { get; set; }

        [RegularExpression("0|1|2|3|4|5", ErrorMessage = "Choose category")]
        public string? Category { get; set; }
    }
}
