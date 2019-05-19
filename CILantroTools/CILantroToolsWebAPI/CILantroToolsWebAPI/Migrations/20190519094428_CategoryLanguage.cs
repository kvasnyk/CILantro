using Microsoft.EntityFrameworkCore.Migrations;

namespace CILantroToolsWebAPI.Migrations
{
    public partial class CategoryLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Categories");
        }
    }
}
