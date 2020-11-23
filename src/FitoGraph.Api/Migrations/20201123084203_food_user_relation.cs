using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class food_user_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TUserId",
                table: "TFood",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TFood_TUserId",
                table: "TFood",
                column: "TUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TFood_TUser_TUserId",
                table: "TFood",
                column: "TUserId",
                principalTable: "TUser",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TFood_TUser_TUserId",
                table: "TFood");

            migrationBuilder.DropIndex(
                name: "IX_TFood_TUserId",
                table: "TFood");

            migrationBuilder.DropColumn(
                name: "TUserId",
                table: "TFood");
        }
    }
}
