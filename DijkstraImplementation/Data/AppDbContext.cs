using DijkstraImplementation.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DijkstraImplementation.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options) 
        {

        }

        public DbSet<Route> Routes { get; set; }
        public DbSet<BusInfo> BusInfos {  get; set; }
        public DbSet<BusSchedule> BusSchedules { get; set; }
        public DbSet <Booking> Bookings { get; set; }
        public DbSet <User> Users { get; set; }

    }
}
