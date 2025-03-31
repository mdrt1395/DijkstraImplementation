using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.Entities
{
    public class BusSeat
    {
        [Key]
        public virtual int BusSeatId { get; set; }    
        [Range(1, 10, ErrorMessage = "Seat must be between 1 and 10.")]
        public int SeatNumber { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<User> Users { get; } = new List<User>();




    }
}
