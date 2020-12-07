using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class food_extra_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "TFood",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TFoodAllergy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TFoodId = table.Column<int>(nullable: false),
                    TAllergyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFoodAllergy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TFoodAllergy_TAllergy_TAllergyId",
                        column: x => x.TAllergyId,
                        principalTable: "TAllergy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TFoodAllergy_TFood_TFoodId",
                        column: x => x.TFoodId,
                        principalTable: "TFood",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TFoodDeficiency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TFoodId = table.Column<int>(nullable: false),
                    TDeficiencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFoodDeficiency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TFoodDeficiency_TDeficiency_TDeficiencyId",
                        column: x => x.TDeficiencyId,
                        principalTable: "TDeficiency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TFoodDeficiency_TFood_TFoodId",
                        column: x => x.TFoodId,
                        principalTable: "TFood",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TFoodDiet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TFoodId = table.Column<int>(nullable: false),
                    TDietId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFoodDiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TFoodDiet_TDiet_TDietId",
                        column: x => x.TDietId,
                        principalTable: "TDiet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TFoodDiet_TFood_TFoodId",
                        column: x => x.TFoodId,
                        principalTable: "TFood",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TFoodNutritionCondition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TFoodId = table.Column<int>(nullable: false),
                    TNutritionConditionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFoodNutritionCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TFoodNutritionCondition_TFood_TFoodId",
                        column: x => x.TFoodId,
                        principalTable: "TFood",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TFoodNutritionCondition_TNutritionCondition_TNutritionConditionId",
                        column: x => x.TNutritionConditionId,
                        principalTable: "TNutritionCondition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TFoodAllergy_TAllergyId",
                table: "TFoodAllergy",
                column: "TAllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_TFoodAllergy_TFoodId",
                table: "TFoodAllergy",
                column: "TFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_TFoodDeficiency_TDeficiencyId",
                table: "TFoodDeficiency",
                column: "TDeficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TFoodDeficiency_TFoodId",
                table: "TFoodDeficiency",
                column: "TFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_TFoodDiet_TDietId",
                table: "TFoodDiet",
                column: "TDietId");

            migrationBuilder.CreateIndex(
                name: "IX_TFoodDiet_TFoodId",
                table: "TFoodDiet",
                column: "TFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_TFoodNutritionCondition_TFoodId",
                table: "TFoodNutritionCondition",
                column: "TFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_TFoodNutritionCondition_TNutritionConditionId",
                table: "TFoodNutritionCondition",
                column: "TNutritionConditionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TFoodAllergy");

            migrationBuilder.DropTable(
                name: "TFoodDeficiency");

            migrationBuilder.DropTable(
                name: "TFoodDiet");

            migrationBuilder.DropTable(
                name: "TFoodNutritionCondition");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "TFood");
        }
    }
}
