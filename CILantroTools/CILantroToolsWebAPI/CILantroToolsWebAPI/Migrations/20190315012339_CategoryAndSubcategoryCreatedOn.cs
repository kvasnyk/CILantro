using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CILantroToolsWebAPI.Migrations
{
    public partial class CategoryAndSubcategoryCreatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Subcategories",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Categories",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Categories");
        }
    }
}
