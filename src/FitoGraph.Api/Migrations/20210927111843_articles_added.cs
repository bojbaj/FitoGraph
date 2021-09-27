using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class articles_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TArticle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TArticle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TArticleSport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TArticleId = table.Column<int>(nullable: false),
                    TSportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TArticleSport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TArticleSport_TArticle_TArticleId",
                        column: x => x.TArticleId,
                        principalTable: "TArticle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TArticleSport_TSport_TSportId",
                        column: x => x.TSportId,
                        principalTable: "TSport",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TArticleSport_TArticleId",
                table: "TArticleSport",
                column: "TArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_TArticleSport_TSportId",
                table: "TArticleSport",
                column: "TSportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TArticleSport");

            migrationBuilder.DropTable(
                name: "TArticle");
        }
    }
}
