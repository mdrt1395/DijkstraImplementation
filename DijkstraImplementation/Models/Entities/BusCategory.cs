using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Models.Entities
{
    public class BusCategory
    {
        [Key]
        public required Guid BusCategoryId { get; set; }
        public string? Category { get; set; }
    }
}
