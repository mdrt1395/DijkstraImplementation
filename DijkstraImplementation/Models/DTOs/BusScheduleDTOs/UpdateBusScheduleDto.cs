using DijkstraImplementation.Utility;
using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.DTOs.BusScheduleDTOs
{
    public class UpdateBusScheduleDto
    {
        public required string BusScheduleId { get; set; }
        [Required]
        [ArrivalTimeVsDepartureTime(nameof(DepartureTime))]
        public required DateTime ArrivalTime { get; set; }
        public required DateTime DepartureTime { get; set; }
    }
}
