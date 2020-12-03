using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class reference_range : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TReferenceInRange",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    FromAge = table.Column<int>(nullable: false),
                    ToAge = table.Column<int>(nullable: false),
                    TReferenceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TReferenceInRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TReferenceInRange_TReference_TReferenceId",
                        column: x => x.TReferenceId,
                        principalTable: "TReference",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TReferenceInRange_TReferenceId",
                table: "TReferenceInRange",
                column: "TReferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TReferenceInRange");
        }
    }
}
