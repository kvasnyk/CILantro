using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CILantroToolsWebAPI.Migrations
{
    public partial class CategoryAndSubcategoryForTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Tests",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubcategoryId",
                table: "Tests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CategoryId",
                table: "Tests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SubcategoryId",
                table: "Tests",
                column: "SubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Categories_CategoryId",
                table: "Tests",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Subcategories_SubcategoryId",
                table: "Tests",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Categories_CategoryId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Subcategories_SubcategoryId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_CategoryId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_SubcategoryId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "Tests");
        }
    }
}
