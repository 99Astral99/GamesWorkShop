using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GamesWorkshop.Domain.View.ProfileModels
{
    public class UserAccountViewModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }  
        public string Country { get; set; }
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Maximum 250 characters")]
        public string Address { get; set; }
        public string Email { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The First Name must be a maximum of 50 characters long.")]
        public string? FirstName { get; set; } //unlock
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The Last Name must be a maximum of 50 characters long.")]
        public string? LastName { get; set; }
        public int Age { get; set; }
    }
}
