namespace DijkstraImplementation.Models.Entities
{
    public class BusSchedule
    {
        public Guid BusLine { get; set; }
        public required BusInfo BusInfo { get; set; }

        public required string Origin { get; set; }
        public  required Route Route { get; set; }

        public required int DepartureTime { get; set; }
        public required int ArrivalTime { get; set; }
    }
}
