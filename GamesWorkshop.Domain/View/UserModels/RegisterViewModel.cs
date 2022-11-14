using System.ComponentModel.DataAnnotations;

namespace GamesWorkshop.Domain.View.UserModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter a name")]
        [MaxLength(25, ErrorMessage = "Name must be less than 25 characters")]
        [MinLength(3, ErrorMessage = "Name must be more than 3 characters")]
        public string Name { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
