using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CILantroToolsWebAPI.Migrations
{
    public partial class TestLastOpenedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastOpenedOn",
                table: "Tests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastOpenedOn",
                table: "Tests");
        }
    }
}
