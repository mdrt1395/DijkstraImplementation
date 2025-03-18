using DijkstraImplementation.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DijkstraImplementation.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options) 
        {

        }
        public DbSet <User> Users { get; set; }
        public DbSet<BusInfo> BusInfos {  get; set; }
        public DbSet<BusSchedule> BusSchedules { get; set; }
        public DbSet<RouteInfo> Routes { get; set; }
        public DbSet<BusStatus> BusStatuses { get; set; }
        public DbSet<BusSeat> BusSeats { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BusSeat>()
                .HasKey(b => new { b.SeatNumber });

            modelBuilder.Entity<BusSeat>()
                .HasOne(bs => bs.User)
                .WithMany()
                .HasForeignKey(bs => bs.Name)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BusSeat>()
               .HasOne(bs => bs.RouteInfo)
               .WithMany()
               .HasForeignKey(bs => bs.RouteName)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BusSeat>()
               .HasOne(bs => bs.BusInfo)
               .WithMany()
               .HasForeignKey(bs => bs.BusPlates)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BusSchedule>()
                .HasKey(b => new { b.BusScheduleId });

            modelBuilder.Entity<BusSchedule>()
                .HasOne(b => b.BusInfo)
                .WithMany()
                .HasForeignKey(b => b.BusPlates)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BusSchedule>()
                .HasOne(b => b.RouteInfo)
                .WithMany()
                .HasForeignKey(b => b.RouteName)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BusInfo>()
                .HasKey(b => new { b.BusPlates });

            modelBuilder.Entity<RouteInfo>()
                .HasKey(b => new { b.RouteName });

            modelBuilder.Entity<User>()
                .HasKey(b => new { b.Username });
        }
    }

}

