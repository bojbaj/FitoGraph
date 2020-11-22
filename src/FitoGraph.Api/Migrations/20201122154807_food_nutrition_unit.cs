using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class food_nutrition_unit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "TFoodNutrition");

            migrationBuilder.AddColumn<int>(
                name: "TNutritionUnitId",
                table: "TFoodNutrition",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TReferenceId",
                table: "TFoodNutrition",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TNutritionUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    AmountInGram = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TNutritionUnit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TFoodNutrition_TNutritionUnitId",
                table: "TFoodNutrition",
                column: "TNutritionUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TFoodNutrition_TReferenceId",
                table: "TFoodNutrition",
                column: "TReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TFoodNutrition_TNutritionUnit_TNutritionUnitId",
                table: "TFoodNutrition",
                column: "TNutritionUnitId",
                principalTable: "TNutritionUnit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TFoodNutrition_TReference_TReferenceId",
                table: "TFoodNutrition",
                column: "TReferenceId",
                principalTable: "TReference",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TFoodNutrition_TNutritionUnit_TNutritionUnitId",
                table: "TFoodNutrition");

            migrationBuilder.DropForeignKey(
                name: "FK_TFoodNutrition_TReference_TReferenceId",
                table: "TFoodNutrition");

            migrationBuilder.DropTable(
                name: "TNutritionUnit");

            migrationBuilder.DropIndex(
                name: "IX_TFoodNutrition_TNutritionUnitId",
                table: "TFoodNutrition");

            migrationBuilder.DropIndex(
                name: "IX_TFoodNutrition_TReferenceId",
                table: "TFoodNutrition");

            migrationBuilder.DropColumn(
                name: "TNutritionUnitId",
                table: "TFoodNutrition");

            migrationBuilder.DropColumn(
                name: "TReferenceId",
                table: "TFoodNutrition");

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "TFoodNutrition",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
