﻿// <auto-generated />
using System;
using DijkstraImplementation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DijkstraImplementation.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250319175544_thirdMigration")]
    partial class thirdMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusInfo", b =>
                {
                    b.Property<string>("BusPlates")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.HasKey("BusPlates");

                    b.ToTable("BusInfos");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusSchedule", b =>
                {
                    b.Property<string>("BusScheduleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("BusPlates")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RouteName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BusScheduleId");

                    b.HasIndex("BusPlates");

                    b.HasIndex("RouteName");

                    b.ToTable("BusSchedules");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusSeat", b =>
                {
                    b.Property<int>("SeatNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatNumber"));

                    b.Property<string>("BusPlates")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RouteName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SeatNumber");

                    b.HasIndex("BusPlates");

                    b.HasIndex("Name");

                    b.HasIndex("RouteName");

                    b.ToTable("BusSeats");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusStatus", b =>
                {
                    b.Property<Guid>("BusStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BusStatusId");

                    b.ToTable("BusStatuses");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.RouteInfo", b =>
                {
                    b.Property<string>("RouteName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Destiny")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteName");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusSchedule", b =>
                {
                    b.HasOne("DijkstraImplementation.Models.Entities.BusInfo", "BusInfo")
                        .WithMany()
                        .HasForeignKey("BusPlates")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DijkstraImplementation.Models.Entities.RouteInfo", "RouteInfo")
                        .WithMany()
                        .HasForeignKey("RouteName")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("BusInfo");

                    b.Navigation("RouteInfo");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusSeat", b =>
                {
                    b.HasOne("DijkstraImplementation.Models.Entities.BusInfo", "BusInfo")
                        .WithMany()
                        .HasForeignKey("BusPlates")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DijkstraImplementation.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Name")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DijkstraImplementation.Models.Entities.RouteInfo", "RouteInfo")
                        .WithMany()
                        .HasForeignKey("RouteName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("BusInfo");

                    b.Navigation("RouteInfo");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
