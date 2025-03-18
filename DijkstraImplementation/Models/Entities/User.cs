namespace DijkstraImplementation.Models.Entities
{
    public class User
    {
        public required string Name { get; set; }  
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required bool IsAdmin { get; set; }  
    }
}
