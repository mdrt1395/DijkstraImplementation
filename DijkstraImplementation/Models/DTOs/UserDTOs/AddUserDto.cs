using System.ComponentModel.DataAnnotations;
using DijkstraImplementation.Utility;

namespace DijkstraImplementation.Models.DTOs.UserDTOs
{
    public class AddUserDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 20 characters.")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username should be between 5 and 20 characters.")]
        public required string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [PasswordSecurity]
        [StringLength(14, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 14 characters.")]
        public required string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
