using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class user_body_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Fat",
                table: "TUser",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Forearms",
                table: "TUser",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "TUser",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Hips",
                table: "TUser",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Waist",
                table: "TUser",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "TUser",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fat",
                table: "TUser");

            migrationBuilder.DropColumn(
                name: "Forearms",
                table: "TUser");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "TUser");

            migrationBuilder.DropColumn(
                name: "Hips",
                table: "TUser");

            migrationBuilder.DropColumn(
                name: "Waist",
                table: "TUser");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "TUser");
        }
    }
}
