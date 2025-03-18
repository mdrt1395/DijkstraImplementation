namespace DijkstraImplementation.Models.Entities
{
    public class Routes
    {
        public required string Origin {  get; set; }
        public required string Destiny { get; set; }
        public required int Distance    { get; set; }
        public required int Time { get; set; }
    }
}
