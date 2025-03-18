using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DijkstraImplementation.Models.Entities
{
    public class BusStatus
    {
        [Key]
        public required Guid Id { get; set; }
        public string? Status { get; set; }
    }
}
