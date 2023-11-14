using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace SalesGO.Services.Customer.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "outletLat",
                table: "Setup_Outlet");

            migrationBuilder.DropColumn(
                name: "outletLong",
                table: "Setup_Outlet");

            migrationBuilder.AddColumn<Point>(
                name: "Location",
                table: "Setup_Outlet",
                type: "geography",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Setup_Outlet");

            migrationBuilder.AddColumn<double>(
                name: "outletLat",
                table: "Setup_Outlet",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "outletLong",
                table: "Setup_Outlet",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
