using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesGO.Services.Customer.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "outletLat",
                table: "Setup_Outlet");

            migrationBuilder.DropColumn(
                name: "outletLong",
                table: "Setup_Outlet");
        }
    }
}
