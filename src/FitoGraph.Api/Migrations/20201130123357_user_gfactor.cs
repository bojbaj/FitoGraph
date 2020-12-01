using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class user_gfactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TReferenceId",
                table: "TUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TUser_TReferenceId",
                table: "TUser",
                column: "TReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TUser_TReference_TReferenceId",
                table: "TUser",
                column: "TReferenceId",
                principalTable: "TReference",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TUser_TReference_TReferenceId",
                table: "TUser");

            migrationBuilder.DropIndex(
                name: "IX_TUser_TReferenceId",
                table: "TUser");

            migrationBuilder.DropColumn(
                name: "TReferenceId",
                table: "TUser");
        }
    }
}
