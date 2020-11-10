using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class food_nutrition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TNutritionGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TNutritionGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TReference",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    RecordId = table.Column<int>(nullable: false),
                    RecordType = table.Column<int>(nullable: false),
                    Energy = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    carbohydrate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Fat = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Ash = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Dietary_Fibre = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Fructose = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Glucose = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Sucrose = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Lactose = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total_Sugars = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Starch = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Calcium = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Chloride = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Cupper = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Fluoride = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Iodine = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Iron = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Magnesium = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Manganese = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Phosphorus = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Potassium = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Selenium = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Sodium = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Sulphur = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Tin = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Zinc = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Alpha_Carotene = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Beta_Carotene = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Cryptoxanthin = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Vitamin_A = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Lutein = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Lycopene = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Thiamin_B1 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Riboflavin_B2 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Niacin_B3 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Pantothenic_Acid_B5 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Vitamin_B6 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Biotin_B7 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Vitamin_B12 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Folate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Folic_Acid = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Vitamin_C = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Vitamin_D = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Molybdenum = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Chromium = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Vitamin_E = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total_Saturated_Fatty_Acids = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total_Monounsaturated_Fatty_Acids = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total_Polyunsaturated_Fatty_Acids = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total_Long_Chain_Omega_3_Fatty_Acids = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total_Trans_Fatty_Acids = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Caffeine = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Cholesterol = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TReference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TFood",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    TReferenceId = table.Column<int>(nullable: false),
                    TFoodTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TFood_TFoodType_TFoodTypeId",
                        column: x => x.TFoodTypeId,
                        principalTable: "TFoodType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TFood_TReference_TReferenceId",
                        column: x => x.TReferenceId,
                        principalTable: "TReference",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TNutrition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    TNutritionGroupId = table.Column<int>(nullable: false),
                    TReferenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TNutrition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TNutrition_TNutritionGroup_TNutritionGroupId",
                        column: x => x.TNutritionGroupId,
                        principalTable: "TNutritionGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TNutrition_TReference_TReferenceId",
                        column: x => x.TReferenceId,
                        principalTable: "TReference",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TFoodNutrition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TFoodId = table.Column<int>(nullable: false),
                    TNutritionId = table.Column<int>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFoodNutrition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TFoodNutrition_TFood_TFoodId",
                        column: x => x.TFoodId,
                        principalTable: "TFood",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TFoodNutrition_TNutrition_TNutritionId",
                        column: x => x.TNutritionId,
                        principalTable: "TNutrition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TFood_TFoodTypeId",
                table: "TFood",
                column: "TFoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TFood_TReferenceId",
                table: "TFood",
                column: "TReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_TFoodNutrition_TFoodId",
                table: "TFoodNutrition",
                column: "TFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_TFoodNutrition_TNutritionId",
                table: "TFoodNutrition",
                column: "TNutritionId");

            migrationBuilder.CreateIndex(
                name: "UQ_TNutrition_Code",
                table: "TNutrition",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TNutrition_TNutritionGroupId",
                table: "TNutrition",
                column: "TNutritionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TNutrition_TReferenceId",
                table: "TNutrition",
                column: "TReferenceId");

            migrationBuilder.CreateIndex(
                name: "UQ_TNutritionGroup_Code",
                table: "TNutritionGroup",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TFoodNutrition");

            migrationBuilder.DropTable(
                name: "TFood");

            migrationBuilder.DropTable(
                name: "TNutrition");

            migrationBuilder.DropTable(
                name: "TNutritionGroup");

            migrationBuilder.DropTable(
                name: "TReference");
        }
    }
}
