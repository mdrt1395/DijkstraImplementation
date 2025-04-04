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
    [Migration("20250330191026_anotherAttempt")]
    partial class anotherAttempt
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
                    b.Property<int>("BusInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusInfoId"));

                    b.Property<string>("BusPlates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.HasKey("BusInfoId");

                    b.ToTable("BusInfos");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusSchedule", b =>
                {
                    b.Property<string>("BusScheduleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BusInfoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RouteInfoId")
                        .HasColumnType("int");

                    b.HasKey("BusScheduleId");

                    b.HasIndex("BusInfoId");

                    b.HasIndex("RouteInfoId");

                    b.ToTable("BusSchedules");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusSeat", b =>
                {
                    b.Property<int>("BusSeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusSeatId"));

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BusSeatId");

                    b.HasIndex("UserId");

                    b.ToTable("BusSeats");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.RouteInfo", b =>
                {
                    b.Property<int>("RouteInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteInfoId"));

                    b.Property<string>("Destiny")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RouteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteInfoId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int?>("BusSeatId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("BusSeatId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusSchedule", b =>
                {
                    b.HasOne("DijkstraImplementation.Models.Entities.BusInfo", "BusInfo")
                        .WithMany("BusSchedules")
                        .HasForeignKey("BusInfoId");

                    b.HasOne("DijkstraImplementation.Models.Entities.RouteInfo", "RouteInfo")
                        .WithMany("BusSchedules")
                        .HasForeignKey("RouteInfoId");

                    b.Navigation("BusInfo");

                    b.Navigation("RouteInfo");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusSeat", b =>
                {
                    b.HasOne("DijkstraImplementation.Models.Entities.User", "User")
                        .WithMany("BusSeats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.User", b =>
                {
                    b.HasOne("DijkstraImplementation.Models.Entities.BusSeat", "BusSeat")
                        .WithMany("Users")
                        .HasForeignKey("BusSeatId");

                    b.Navigation("BusSeat");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusInfo", b =>
                {
                    b.Navigation("BusSchedules");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.BusSeat", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.RouteInfo", b =>
                {
                    b.Navigation("BusSchedules");
                });

            modelBuilder.Entity("DijkstraImplementation.Models.Entities.User", b =>
                {
                    b.Navigation("BusSeats");
                });
#pragma warning restore 612, 618
        }
    }
}
