using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesGO.Services.Catelog.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productSubCategoryFieldId",
                table: "Product_SelectedFields",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productSubCategoryFieldId",
                table: "Product_SelectedFields");
        }
    }
}
