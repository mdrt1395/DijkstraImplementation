using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.Entities
{
    public class BusSeat
    {
        [Key]
        [Range(1, 10, ErrorMessage = "Seat must be between 1 and 10.")]

        public int SeatNumber { get; set; }

        public string? Name { get; set; }
        public virtual User? User { get; set; }  // Navigation Property

        public string? RouteName { get; set; }
        public virtual RouteInfo? RouteInfo { get; set; }  // Navigation Property

        public string? BusPlates { get; set; }
        public virtual BusInfo? BusInfo { get; set; }  // Navigation Property


    } 
}
