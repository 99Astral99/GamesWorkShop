using System.ComponentModel.DataAnnotations;

namespace GamesWorkshop.Domain.View.ProfileModels
{
    public class UserAccountViewModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Maximum 250 characters")]
        public string Address { get; set; }
        public int Age { get; set; }
    }
}
