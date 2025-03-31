using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.Entities
{
    public class RouteInfo
    {
        [Key]
        public virtual int RouteInfoId { get; set; }
        public required string RouteName { get; set; } 
        public required string Origin { get; set; }
        public required string Destiny { get; set; }
        public required double Distance { get; set; }
        public ICollection<BusSchedule> BusSchedules { get; } = new List<BusSchedule>();
    }
}
