namespace DijkstraImplementation.Models.DTOs.UserDTOs
{
    public class AddUserDto
    {
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
