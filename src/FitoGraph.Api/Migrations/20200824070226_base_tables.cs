using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class base_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TActivityLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    PALForMale = table.Column<double>(nullable: false),
                    PALForFeMale = table.Column<double>(nullable: false),
                    Protein = table.Column<double>(nullable: false),
                    Carb = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TActivityLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TAllergy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAllergy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBodyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBodyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TDeficiency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDeficiency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TDiet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDiet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TFoodType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFoodType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TGoal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGoal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TNutritionCondition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TNutritionCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TSport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TWeeklyGoal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TGoalId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWeeklyGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TWeeklyGoal_TGoal_TGoalId",
                        column: x => x.TGoalId,
                        principalTable: "TGoal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    FireBaseId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    TBodyTypeId = table.Column<int>(nullable: true),
                    TActivityLevelId = table.Column<int>(nullable: true),
                    TGoalId = table.Column<int>(nullable: true),
                    TWeeklyGoalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUser_TActivityLevel_TActivityLevelId",
                        column: x => x.TActivityLevelId,
                        principalTable: "TActivityLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TUser_TBodyType_TBodyTypeId",
                        column: x => x.TBodyTypeId,
                        principalTable: "TBodyType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TUser_TGoal_TGoalId",
                        column: x => x.TGoalId,
                        principalTable: "TGoal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TUser_TWeeklyGoal_TWeeklyGoalId",
                        column: x => x.TWeeklyGoalId,
                        principalTable: "TWeeklyGoal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TUserAllergy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TUserId = table.Column<int>(nullable: false),
                    TAllergyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUserAllergy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUserAllergy_TAllergy_TAllergyId",
                        column: x => x.TAllergyId,
                        principalTable: "TAllergy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TUserAllergy_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TUserDeficiency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TUserId = table.Column<int>(nullable: false),
                    TDeficiencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUserDeficiency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUserDeficiency_TDeficiency_TDeficiencyId",
                        column: x => x.TDeficiencyId,
                        principalTable: "TDeficiency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TUserDeficiency_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TUserDiet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TUserId = table.Column<int>(nullable: false),
                    TDietId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUserDiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUserDiet_TDiet_TDietId",
                        column: x => x.TDietId,
                        principalTable: "TDiet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TUserDiet_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TUserFoodType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TUserId = table.Column<int>(nullable: false),
                    TFoodTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUserFoodType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUserFoodType_TFoodType_TFoodTypeId",
                        column: x => x.TFoodTypeId,
                        principalTable: "TFoodType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TUserFoodType_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TUserNutritionCondition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TUserId = table.Column<int>(nullable: false),
                    TNutritionConditionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUserNutritionCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUserNutritionCondition_TNutritionCondition_TNutritionConditionId",
                        column: x => x.TNutritionConditionId,
                        principalTable: "TNutritionCondition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TUserNutritionCondition_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TUserSport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TUserId = table.Column<int>(nullable: false),
                    TSportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUserSport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUserSport_TSport_TSportId",
                        column: x => x.TSportId,
                        principalTable: "TSport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TUserSport_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TUser_TActivityLevelId",
                table: "TUser",
                column: "TActivityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TUser_TBodyTypeId",
                table: "TUser",
                column: "TBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TUser_TGoalId",
                table: "TUser",
                column: "TGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_TUser_TWeeklyGoalId",
                table: "TUser",
                column: "TWeeklyGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserAllergy_TAllergyId",
                table: "TUserAllergy",
                column: "TAllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserAllergy_TUserId",
                table: "TUserAllergy",
                column: "TUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserDeficiency_TDeficiencyId",
                table: "TUserDeficiency",
                column: "TDeficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserDeficiency_TUserId",
                table: "TUserDeficiency",
                column: "TUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserDiet_TDietId",
                table: "TUserDiet",
                column: "TDietId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserDiet_TUserId",
                table: "TUserDiet",
                column: "TUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserFoodType_TFoodTypeId",
                table: "TUserFoodType",
                column: "TFoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserFoodType_TUserId",
                table: "TUserFoodType",
                column: "TUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserNutritionCondition_TNutritionConditionId",
                table: "TUserNutritionCondition",
                column: "TNutritionConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserNutritionCondition_TUserId",
                table: "TUserNutritionCondition",
                column: "TUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserSport_TSportId",
                table: "TUserSport",
                column: "TSportId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserSport_TUserId",
                table: "TUserSport",
                column: "TUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TWeeklyGoal_TGoalId",
                table: "TWeeklyGoal",
                column: "TGoalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TUserAllergy");

            migrationBuilder.DropTable(
                name: "TUserDeficiency");

            migrationBuilder.DropTable(
                name: "TUserDiet");

            migrationBuilder.DropTable(
                name: "TUserFoodType");

            migrationBuilder.DropTable(
                name: "TUserNutritionCondition");

            migrationBuilder.DropTable(
                name: "TUserSport");

            migrationBuilder.DropTable(
                name: "TAllergy");

            migrationBuilder.DropTable(
                name: "TDeficiency");

            migrationBuilder.DropTable(
                name: "TDiet");

            migrationBuilder.DropTable(
                name: "TFoodType");

            migrationBuilder.DropTable(
                name: "TNutritionCondition");

            migrationBuilder.DropTable(
                name: "TSport");

            migrationBuilder.DropTable(
                name: "TUser");

            migrationBuilder.DropTable(
                name: "TActivityLevel");

            migrationBuilder.DropTable(
                name: "TBodyType");

            migrationBuilder.DropTable(
                name: "TWeeklyGoal");

            migrationBuilder.DropTable(
                name: "TGoal");
        }
    }
}
