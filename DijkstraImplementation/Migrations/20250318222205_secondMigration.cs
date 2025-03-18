using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DijkstraImplementation.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusSeats_Users_Name",
                table: "BusSeats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "BusInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "BusStatusId",
                table: "BusStatuses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "RouteName",
                table: "BusSchedules",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BusPlates",
                table: "BusSchedules",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "BusCategoryId",
                table: "BusInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusStatuses",
                table: "BusStatuses",
                column: "BusStatusId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BusSeats_Users_Name",
                table: "BusSeats",
                column: "Name",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusInfos_BusCategory_BusCategoryId",
                table: "BusInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_BusSeats_Users_Name",
                table: "BusSeats");

            migrationBuilder.DropTable(
                name: "BusCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusStatuses",
                table: "BusStatuses");

            migrationBuilder.DropIndex(
                name: "IX_BusInfos_BusCategoryId",
                table: "BusInfos");

            migrationBuilder.DropColumn(
                name: "BusStatusId",
                table: "BusStatuses");

            migrationBuilder.DropColumn(
                name: "BusCategoryId",
                table: "BusInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RouteName",
                table: "BusSchedules",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusPlates",
                table: "BusSchedules",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "BusInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_BusSeats_Users_Name",
                table: "BusSeats",
                column: "Name",
                principalTable: "Users",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
