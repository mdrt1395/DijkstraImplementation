using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DijkstraImplementation.Migrations
{
    /// <inheritdoc />
    public partial class thirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusInfos_BusCategory_BusCategoryId",
                table: "BusInfos");

            migrationBuilder.DropTable(
                name: "BusCategory");

            migrationBuilder.DropIndex(
                name: "IX_BusInfos_BusCategoryId",
                table: "BusInfos");

            migrationBuilder.DropColumn(
                name: "BusCategoryId",
                table: "BusInfos");

            migrationBuilder.AlterColumn<string>(
                name: "RouteName",
                table: "BusSeats",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BusSeats",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BusPlates",
                table: "BusSeats",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RouteName",
                table: "BusSeats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BusSeats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusPlates",
                table: "BusSeats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BusCategoryId",
                table: "BusInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BusCategory",
                columns: table => new
                {
                    BusCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusCategory", x => x.BusCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusInfos_BusCategoryId",
                table: "BusInfos",
                column: "BusCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusInfos_BusCategory_BusCategoryId",
                table: "BusInfos",
                column: "BusCategoryId",
                principalTable: "BusCategory",
                principalColumn: "BusCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
