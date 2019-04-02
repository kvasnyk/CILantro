using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CILantroToolsWebAPI.Migrations
{
    public partial class TestRunStepsAndItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestRunSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProcessedForMilliseconds = table.Column<int>(nullable: false),
                    Step = table.Column<int>(nullable: false),
                    TestRunId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRunSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRunSteps_TestRuns_TestRunId",
                        column: x => x.TestRunId,
                        principalTable: "TestRuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestRunStepItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProcessedForMilliseconds = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StepId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRunStepItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRunStepItems_TestRunSteps_StepId",
                        column: x => x.StepId,
                        principalTable: "TestRunSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestRunStepItems_StepId",
                table: "TestRunStepItems",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRunSteps_TestRunId",
                table: "TestRunSteps",
                column: "TestRunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestRunStepItems");

            migrationBuilder.DropTable(
                name: "TestRunSteps");
        }
    }
}
