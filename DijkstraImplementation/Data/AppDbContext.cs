using System.Reflection.Metadata;
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
        public DbSet<RouteInfo> Routes { get; set; }
        public DbSet<BusSeat> BusSeats { get; set; }
        public DbSet<BusInfo> BusInfos {  get; set; }
        public DbSet<BusSchedule> BusSchedules { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BusSeats)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<BusSeat>()
                .HasMany(e => e.Users)
                .WithOne(e => e.BusSeat)
                .HasForeignKey(e => e.BusSeatId);


            modelBuilder.Entity<RouteInfo>()
                .HasMany(e => e.BusSchedules)
                .WithOne(e => e.RouteInfo)
                .HasForeignKey(e => e.RouteInfoId);



            modelBuilder.Entity<BusInfo>()
                .HasMany(e => e.BusSchedules)
                .WithOne(e => e.BusInfo)
                .HasForeignKey(e => e.BusInfoId);



        }
    }

}

