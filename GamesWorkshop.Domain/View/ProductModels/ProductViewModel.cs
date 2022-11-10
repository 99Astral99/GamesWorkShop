using AutoMapper;
using GamesWorkshop.Domain.Entities;
using GamesWorkshop.Domain.Interfaces;

namespace GamesWorkshop.Domain.View.ProductModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ImageSrc { get; set; }
        public string? Category { get; set; }
    }
}
