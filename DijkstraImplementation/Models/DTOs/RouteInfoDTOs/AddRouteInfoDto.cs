namespace DijkstraImplementation.Models.DTOs.RouteInfoDTOs
{
    public class AddRouteInfoDto
    {
        public required string RouteName { get; set; }
        public required string Origin { get; set; }
        public required string Destiny { get; set; }
        public required double Distance { get; set; }
    }
}
