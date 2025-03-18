using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.Entities
{
    public class RouteInfo
    {
        [Key]
        public required string RouteName { get; set; } //Identifier
        public required string Origin { get; set; }
        public required string Destiny { get; set; }
        public required double Distance { get; set; }
    }
}
