using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class supplier_share_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShareAccount",
                table: "TUser",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SharePercent",
                table: "TUser",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShareAccount",
                table: "TUser");

            migrationBuilder.DropColumn(
                name: "SharePercent",
                table: "TUser");
        }
    }
}
