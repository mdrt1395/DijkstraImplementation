using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.Entities
{
    public class User
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 20 characters.")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username should be between 5 and 20 characters.")]

        public required string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(14, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 14 characters.")]

        public required string Password { get; set; }
        public required bool IsAdmin { get; set; }  
    }
}
