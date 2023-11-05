using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesGO.Services.Catelog.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    brandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.brandId);
                });

            migrationBuilder.CreateTable(
                name: "Product_Categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Categories", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Setup_FieldFormControls",
                columns: table => new
                {
                    fieldFormControlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fieldFormControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    allowPreValues = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setup_FieldFormControls", x => x.fieldFormControlId);
                });

            migrationBuilder.CreateTable(
                name: "Setup_FieldTypes",
                columns: table => new
                {
                    fieldTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fieldName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setup_FieldTypes", x => x.fieldTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Product_subCategories",
                columns: table => new
                {
                    subCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_subCategories", x => x.subCategoryId);
                    table.ForeignKey(
                        name: "FK_Product_subCategories_Product_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Product_Categories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_subCategoryFields",
                columns: table => new
                {
                    subCategoryFieldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subCategoryId = table.Column<int>(type: "int", nullable: false),
                    fieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fieldTypeId = table.Column<int>(type: "int", nullable: false),
                    fieldPreValues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fieldFormControlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_subCategoryFields", x => x.subCategoryFieldId);
                    table.ForeignKey(
                        name: "FK_Product_subCategoryFields_Product_subCategories_subCategoryId",
                        column: x => x.subCategoryId,
                        principalTable: "Product_subCategories",
                        principalColumn: "subCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_subCategoryFields_Setup_FieldFormControls_fieldFormControlId",
                        column: x => x.fieldFormControlId,
                        principalTable: "Setup_FieldFormControls",
                        principalColumn: "fieldFormControlId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_subCategoryFields_Setup_FieldTypes_fieldTypeId",
                        column: x => x.fieldTypeId,
                        principalTable: "Setup_FieldTypes",
                        principalColumn: "fieldTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subCategoryId = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    skuCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_brandId",
                        column: x => x.brandId,
                        principalTable: "Brands",
                        principalColumn: "brandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Product_subCategories_subCategoryId",
                        column: x => x.subCategoryId,
                        principalTable: "Product_subCategories",
                        principalColumn: "subCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_SelectedFields",
                columns: table => new
                {
                    productSelectedFieldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    selectedValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_SelectedFields", x => x.productSelectedFieldId);
                    table.ForeignKey(
                        name: "FK_Product_SelectedFields_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SelectedFields_productId",
                table: "Product_SelectedFields",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_subCategories_categoryId",
                table: "Product_subCategories",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_subCategoryFields_fieldFormControlId",
                table: "Product_subCategoryFields",
                column: "fieldFormControlId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_subCategoryFields_fieldTypeId",
                table: "Product_subCategoryFields",
                column: "fieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_subCategoryFields_subCategoryId",
                table: "Product_subCategoryFields",
                column: "subCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_brandId",
                table: "Products",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_subCategoryId",
                table: "Products",
                column: "subCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_SelectedFields");

            migrationBuilder.DropTable(
                name: "Product_subCategoryFields");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Setup_FieldFormControls");

            migrationBuilder.DropTable(
                name: "Setup_FieldTypes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Product_subCategories");

            migrationBuilder.DropTable(
                name: "Product_Categories");
        }
    }
}
