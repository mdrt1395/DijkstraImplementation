using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.Entities
{
    public class BusSeat
    {
        [Key]  
        public int SeatNumber { get; set; }

        public required string Name { get; set; }
        public required User User { get; set; }  // Navigation Property

        public required string RouteName { get; set; }
        public virtual RouteInfo? RouteInfo { get; set; }  // Navigation Property

        public required string BusPlates { get; set; }
        public virtual BusInfo? BusInfo { get; set; }  // Navigation Property


    } 
}
