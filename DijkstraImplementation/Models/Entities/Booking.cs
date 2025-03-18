namespace DijkstraImplementation.Models.Entities
{
    public class Booking
    {
        public required int Name { get; set; }
        public required User User { get; set; }

        public required string Origin { get; set; }
        public required Routes Routes { get; set; }

        public required int DepartureTime { get; set; }
        public required BusSchedule BusSchedule { get; set; }
    }
}
