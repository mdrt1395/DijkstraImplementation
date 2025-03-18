namespace DijkstraImplementation.Models.DTOs.BusScheduleDTOs
{
    public class UpdateBusScheduleDto
    {
        public required string BusScheduleId { get; set; }
        public required DateTime ArrivalTime { get; set; }
        public required DateTime DepartureTime { get; set; }
    }
}
