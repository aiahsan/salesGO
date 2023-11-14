using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesGO.Services.Customer.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setup_Customers",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerBusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerRepresentativeDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerRepresentativeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setup_Customers", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "Setup_Outlet",
                columns: table => new
                {
                    outletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    outletLat = table.Column<double>(type: "float", nullable: false),
                    outletLong = table.Column<double>(type: "float", nullable: false),
                    outletAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    outletImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    outletContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    outletName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setup_Outlet", x => x.outletId);
                    table.ForeignKey(
                        name: "FK_Setup_Outlet_Setup_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Setup_Customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Setup_Outlet_customerId",
                table: "Setup_Outlet",
                column: "customerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Setup_Outlet");

            migrationBuilder.DropTable(
                name: "Setup_Customers");
        }
    }
}
