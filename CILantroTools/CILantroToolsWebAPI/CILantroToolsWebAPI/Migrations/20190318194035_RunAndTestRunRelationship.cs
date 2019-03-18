using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CILantroToolsWebAPI.Migrations
{
    public partial class RunAndTestRunRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RunId",
                table: "TestRun",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TestRun_RunId",
                table: "TestRun",
                column: "RunId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRun_Runs_RunId",
                table: "TestRun",
                column: "RunId",
                principalTable: "Runs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRun_Runs_RunId",
                table: "TestRun");

            migrationBuilder.DropIndex(
                name: "IX_TestRun_RunId",
                table: "TestRun");

            migrationBuilder.DropColumn(
                name: "RunId",
                table: "TestRun");
        }
    }
}
