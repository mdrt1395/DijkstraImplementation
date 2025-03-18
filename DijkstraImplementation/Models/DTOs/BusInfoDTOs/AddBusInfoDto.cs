namespace DijkstraImplementation.Models.DTOs.BusInfoDTOs
{
    public class AddBusInfoDto
    {
        public required string BusPlates { get; set; }
        public required int NumberOfSeats { get; set; }
        public required bool IsAvailable { get; set; }
    }
}
