using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DijkstraImplementation.Models.Entities
{
    public class BusInfo
    {
        [Key]
        public required int BusInfoId { get; set; }
        public required string BusPlates { get; set; } 
        public required int NumberOfSeats { get; set; }
        public ICollection<BusSchedule> BusSchedules { get; } = new List<BusSchedule>();


    }
}
