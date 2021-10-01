using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class order_unique_id_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    UniqueId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Success = table.Column<bool>(nullable: false),
                    Used = table.Column<bool>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPayment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TPayment");
        }
    }
}
