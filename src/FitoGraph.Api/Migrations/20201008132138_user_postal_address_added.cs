using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class user_postal_address_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "TUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "TUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "TUser");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "TUser");
        }
    }
}
