using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DijkstraImplementation.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusInfos",
                columns: table => new
                {
                    BusPlates = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusInfos", x => x.BusPlates);
                });

            migrationBuilder.CreateTable(
                name: "BusStatuses",
                columns: table => new
                {
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destiny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteName);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "BusSchedules",
                columns: table => new
                {
                    BusScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusPlates = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RouteName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusSchedules", x => x.BusScheduleId);
                    table.ForeignKey(
                        name: "FK_BusSchedules_BusInfos_BusPlates",
                        column: x => x.BusPlates,
                        principalTable: "BusInfos",
                        principalColumn: "BusPlates",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusSchedules_Routes_RouteName",
                        column: x => x.RouteName,
                        principalTable: "Routes",
                        principalColumn: "RouteName");
                });

            migrationBuilder.CreateTable(
                name: "BusSeats",
                columns: table => new
                {
                    SeatNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RouteName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusPlates = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusSeats", x => x.SeatNumber);
                    table.ForeignKey(
                        name: "FK_BusSeats_BusInfos_BusPlates",
                        column: x => x.BusPlates,
                        principalTable: "BusInfos",
                        principalColumn: "BusPlates",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusSeats_Routes_RouteName",
                        column: x => x.RouteName,
                        principalTable: "Routes",
                        principalColumn: "RouteName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusSeats_Users_Name",
                        column: x => x.Name,
                        principalTable: "Users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_BusPlates",
                table: "BusSchedules",
                column: "BusPlates");

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_RouteName",
                table: "BusSchedules",
                column: "RouteName");

            migrationBuilder.CreateIndex(
                name: "IX_BusSeats_BusPlates",
                table: "BusSeats",
                column: "BusPlates");

            migrationBuilder.CreateIndex(
                name: "IX_BusSeats_Name",
                table: "BusSeats",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_BusSeats_RouteName",
                table: "BusSeats",
                column: "RouteName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusSchedules");

            migrationBuilder.DropTable(
                name: "BusSeats");

            migrationBuilder.DropTable(
                name: "BusStatuses");

            migrationBuilder.DropTable(
                name: "BusInfos");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
