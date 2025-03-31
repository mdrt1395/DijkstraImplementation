using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.Entities
{

    public class BusSchedule
    {
        [Key]
        public virtual int BusScheduleId { get; set; } 
        public required DateTime ArrivalTime { get; set; }
        public required DateTime DepartureTime { get; set; }
        public int? RouteInfoId { get; set; }
        public RouteInfo RouteInfo { get; set; } = null!;
        public int? BusInfoId { get; set; }
        public BusInfo BusInfo { get; set; } = null!;
        public TimeSpan TotalTravelingTime => DepartureTime - ArrivalTime; 
    }
}
