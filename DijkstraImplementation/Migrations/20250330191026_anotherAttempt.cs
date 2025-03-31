using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DijkstraImplementation.Migrations
{
    /// <inheritdoc />
    public partial class anotherAttempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusInfos",
                columns: table => new
                {
                    BusInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusPlates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusInfos", x => x.BusInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destiny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteInfoId);
                });

            migrationBuilder.CreateTable(
                name: "BusSchedules",
                columns: table => new
                {
                    BusScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RouteInfoId = table.Column<int>(type: "int", nullable: true),
                    BusInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusSchedules", x => x.BusScheduleId);
                    table.ForeignKey(
                        name: "FK_BusSchedules_BusInfos_BusInfoId",
                        column: x => x.BusInfoId,
                        principalTable: "BusInfos",
                        principalColumn: "BusInfoId");
                    table.ForeignKey(
                        name: "FK_BusSchedules_Routes_RouteInfoId",
                        column: x => x.RouteInfoId,
                        principalTable: "Routes",
                        principalColumn: "RouteInfoId");
                });

            migrationBuilder.CreateTable(
                name: "BusSeats",
                columns: table => new
                {
                    BusSeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusSeats", x => x.BusSeatId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusSeatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_BusSeats_BusSeatId",
                        column: x => x.BusSeatId,
                        principalTable: "BusSeats",
                        principalColumn: "BusSeatId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_BusInfoId",
                table: "BusSchedules",
                column: "BusInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_RouteInfoId",
                table: "BusSchedules",
                column: "RouteInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_BusSeats_UserId",
                table: "BusSeats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BusSeatId",
                table: "Users",
                column: "BusSeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusSeats_Users_UserId",
                table: "BusSeats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusSeats_Users_UserId",
                table: "BusSeats");

            migrationBuilder.DropTable(
                name: "BusSchedules");

            migrationBuilder.DropTable(
                name: "BusInfos");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BusSeats");
        }
    }
}
