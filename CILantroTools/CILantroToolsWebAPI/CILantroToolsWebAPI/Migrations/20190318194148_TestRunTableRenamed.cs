using Microsoft.EntityFrameworkCore.Migrations;

namespace CILantroToolsWebAPI.Migrations
{
    public partial class TestRunTableRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRun_Runs_RunId",
                table: "TestRun");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRun_Tests_TestId",
                table: "TestRun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestRun",
                table: "TestRun");

            migrationBuilder.RenameTable(
                name: "TestRun",
                newName: "TestRuns");

            migrationBuilder.RenameIndex(
                name: "IX_TestRun_TestId",
                table: "TestRuns",
                newName: "IX_TestRuns_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_TestRun_RunId",
                table: "TestRuns",
                newName: "IX_TestRuns_RunId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestRuns",
                table: "TestRuns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRuns_Runs_RunId",
                table: "TestRuns",
                column: "RunId",
                principalTable: "Runs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestRuns_Tests_TestId",
                table: "TestRuns",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRuns_Runs_RunId",
                table: "TestRuns");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRuns_Tests_TestId",
                table: "TestRuns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestRuns",
                table: "TestRuns");

            migrationBuilder.RenameTable(
                name: "TestRuns",
                newName: "TestRun");

            migrationBuilder.RenameIndex(
                name: "IX_TestRuns_TestId",
                table: "TestRun",
                newName: "IX_TestRun_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_TestRuns_RunId",
                table: "TestRun",
                newName: "IX_TestRun_RunId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestRun",
                table: "TestRun",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRun_Runs_RunId",
                table: "TestRun",
                column: "RunId",
                principalTable: "Runs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestRun_Tests_TestId",
                table: "TestRun",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
