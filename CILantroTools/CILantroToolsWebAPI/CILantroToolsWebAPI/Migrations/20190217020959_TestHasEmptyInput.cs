using Microsoft.EntityFrameworkCore.Migrations;

namespace CILantroToolsWebAPI.Migrations
{
    public partial class TestHasEmptyInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasEmptyInput",
                table: "Tests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasEmptyInput",
                table: "Tests");
        }
    }
}
