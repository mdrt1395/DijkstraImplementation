namespace DijkstraImplementation.Models.Entities
{
    public class BusSchedule
    {
        public required string BusScheduleId { get; set; } //Identifier
        public required DateTime ArrivalTime { get; set; }
        public required DateTime DepartureTime { get; set; }
        public required string BusPlates { get; set; } //BusInfo
        public required BusInfo BusInfo { get; set; }
        public required string RouteName { get; set; } //RouteInfo
        public required RouteInfo RouteInfo { get; set; }
        public TimeSpan TotalTravelingTime => DepartureTime - ArrivalTime; //DisplayOnly

    }
}
