using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class region_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TRegionCityId",
                table: "TUser",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TRegionCountry",
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
                    table.PrimaryKey("PK_TRegionCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRegionState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    TRegionCountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRegionState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRegionState_TRegionCountry_TRegionCountryId",
                        column: x => x.TRegionCountryId,
                        principalTable: "TRegionCountry",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TRegionCity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    TRegionStateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRegionCity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRegionCity_TRegionState_TRegionStateId",
                        column: x => x.TRegionStateId,
                        principalTable: "TRegionState",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TUser_TRegionCityId",
                table: "TUser",
                column: "TRegionCityId");

            migrationBuilder.CreateIndex(
                name: "IX_TRegionCity_TRegionStateId",
                table: "TRegionCity",
                column: "TRegionStateId");

            migrationBuilder.CreateIndex(
                name: "IX_TRegionState_TRegionCountryId",
                table: "TRegionState",
                column: "TRegionCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TUser_TRegionCity_TRegionCityId",
                table: "TUser",
                column: "TRegionCityId",
                principalTable: "TRegionCity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TUser_TRegionCity_TRegionCityId",
                table: "TUser");

            migrationBuilder.DropTable(
                name: "TRegionCity");

            migrationBuilder.DropTable(
                name: "TRegionState");

            migrationBuilder.DropTable(
                name: "TRegionCountry");

            migrationBuilder.DropIndex(
                name: "IX_TUser_TRegionCityId",
                table: "TUser");

            migrationBuilder.DropColumn(
                name: "TRegionCityId",
                table: "TUser");
        }
    }
}
