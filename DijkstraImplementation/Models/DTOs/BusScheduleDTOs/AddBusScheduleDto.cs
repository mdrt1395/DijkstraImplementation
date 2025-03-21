using System.ComponentModel.DataAnnotations;
using DijkstraImplementation.Utility;

namespace DijkstraImplementation.Models.DTOs.BusScheduleDTOs
{
    public class AddBusScheduleDto
    {
        public required string BusScheduleId { get; set; }
        [Required]
        [ArrivalTimeVsDepartureTime(nameof(DepartureTime))]
        public required DateTime ArrivalTime { get; set; }
        public required DateTime DepartureTime { get; set; }
    }
}
