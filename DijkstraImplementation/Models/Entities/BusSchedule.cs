namespace DijkstraImplementation.Models.Entities
{
    public class BusSchedule
    {
        public required string BusScheduleId { get; set; } //Identifier
        public required DateTime ArrivalTime { get; set; }
        public required DateTime DepartureTime { get; set; }
        public virtual string? BusPlates { get; set; } //BusInfo
        public  BusInfo? BusInfo { get; set; }
        public virtual string? RouteName { get; set; } //RouteInfo
        public  RouteInfo? RouteInfo { get; set; }
        public TimeSpan TotalTravelingTime => DepartureTime - ArrivalTime; //DisplayOnly

    }
}
