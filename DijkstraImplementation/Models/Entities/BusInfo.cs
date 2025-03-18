namespace DijkstraImplementation.Models.Entities
{
    public class BusInfo
    {
        public required Guid BusId { get; set; }
        public required string Busline { get; set; }
        public string? BusClass { get; set; }


    }
}
