using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DijkstraImplementation.Models.Entities
{
    public class BusInfo
    {
        [Key]
        public required string BusPlates { get; set; } 
        public required int NumberOfSeats { get; set; }
        public required bool IsAvailable { get; set; }
        [ForeignKey("BusCategory")]
        public required Guid BusCategoryId { get; set; }
        public virtual BusCategory BusCategory { get; set; }
       
    }
}
