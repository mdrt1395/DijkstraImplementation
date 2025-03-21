using DijkstraImplementation.Utility;
using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.DTOs.UserDTOs
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "Password is required")]
        [PasswordSecurity]
        [StringLength(14, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 14 characters.")]
        public required string Password { get; set; }
    }
}
