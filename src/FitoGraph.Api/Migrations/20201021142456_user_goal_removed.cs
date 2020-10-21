using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class user_goal_removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TUser_TGoal_TGoalId",
                table: "TUser");

            migrationBuilder.DropIndex(
                name: "IX_TUser_TGoalId",
                table: "TUser");

            migrationBuilder.DropColumn(
                name: "TGoalId",
                table: "TUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TGoalId",
                table: "TUser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TUser_TGoalId",
                table: "TUser",
                column: "TGoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_TUser_TGoal_TGoalId",
                table: "TUser",
                column: "TGoalId",
                principalTable: "TGoal",
                principalColumn: "Id");
        }
    }
}
