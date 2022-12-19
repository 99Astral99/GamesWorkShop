using System.ComponentModel.DataAnnotations;

namespace GamesWorkshop.Domain.View.ProfileModels
{
    public class UserLoginInfoViewModel
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Password must between 10 and 255 characters")]
        //[RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$")]
        public string NewPassword { get; set; }
    }
}
