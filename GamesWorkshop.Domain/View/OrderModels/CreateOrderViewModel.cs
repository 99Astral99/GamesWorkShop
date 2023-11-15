using System.ComponentModel.DataAnnotations;

namespace GamesWorkshop.Domain.View.OrderModels
{
    public class CreateOrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Count")]
        [Range(1, 10, ErrorMessage = "Count must be between 1 and 10")]
        public int Count { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }
        public string Login { get; set; }
    }
}
