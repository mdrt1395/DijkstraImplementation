using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.Entities
{
    public class User
    {
        [Key]
        public required int UserId { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public ICollection<BusSeat> BusSeats { get; } = new List<BusSeat>();
        public int? BusSeatId { get; set; }
        public BusSeat BusSeat { get; set; } = null!;
    }
}
