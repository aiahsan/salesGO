using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesGO.Services.Catelog.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class recheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Setup_FieldTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Setup_FieldTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Setup_FieldTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Setup_FieldTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Setup_FieldTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Setup_FieldFormControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Setup_FieldFormControls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Setup_FieldFormControls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Setup_FieldFormControls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Setup_FieldFormControls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Product_subCategoryFields",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Product_subCategoryFields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Product_subCategoryFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Product_subCategoryFields",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Product_subCategoryFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Product_subCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Product_subCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Product_subCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Product_subCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Product_subCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Product_SelectedFields",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Product_SelectedFields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Product_SelectedFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Product_SelectedFields",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Product_SelectedFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Product_Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Product_Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Product_Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Product_Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Product_Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedAt",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Setup_FieldTypes");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Setup_FieldTypes");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Setup_FieldTypes");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Setup_FieldTypes");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Setup_FieldTypes");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Setup_FieldFormControls");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Setup_FieldFormControls");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Setup_FieldFormControls");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Setup_FieldFormControls");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Setup_FieldFormControls");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Product_subCategoryFields");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Product_subCategoryFields");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Product_subCategoryFields");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Product_subCategoryFields");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Product_subCategoryFields");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Product_subCategories");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Product_subCategories");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Product_subCategories");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Product_subCategories");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Product_subCategories");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Product_SelectedFields");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Product_SelectedFields");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Product_SelectedFields");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Product_SelectedFields");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Product_SelectedFields");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Product_Categories");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Product_Categories");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Product_Categories");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Product_Categories");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Product_Categories");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updatedAt",
                table: "Brands",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "createdAt",
                table: "Brands",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
