using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class reference_calorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Calorie",
                table: "TReference",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calorie",
                table: "TReference");
        }
    }
}
