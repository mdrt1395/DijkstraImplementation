using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.Entities
{

    public class BusSchedule
    {


        public required string BusScheduleId { get; set; } //Identifier
        public required DateTime ArrivalTime { get; set; }
        public required DateTime DepartureTime { get; set; }
        public  string? BusPlates { get; set; } //BusInfo
        public virtual BusInfo? BusInfo { get; set; }
        public  string? RouteName { get; set; } //RouteInfo
        public virtual RouteInfo? RouteInfo { get; set; }
        public TimeSpan TotalTravelingTime => DepartureTime - ArrivalTime; //DisplayOnly

    }
}
