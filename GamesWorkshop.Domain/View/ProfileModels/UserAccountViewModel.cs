using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GamesWorkshop.Domain.View.ProfileModels
{
    public class UserAccountViewModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Country { get; set; }
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Maximum 250 characters")]
        public string Address { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ?FirstName { get; set; } //unlock
        public string ?LastName { get; set; }    
        public int Age { get; set; }
    }
}
