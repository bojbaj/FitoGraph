using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitoGraph.Api.Migrations
{
    public partial class order_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TotalPayablePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TUserId = table.Column<int>(nullable: false),
                    TSupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TOrder_TUser_TSupplierId",
                        column: x => x.TSupplierId,
                        principalTable: "TUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TOrder_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    TFoodId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    RowPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TUserId = table.Column<int>(nullable: false),
                    TOrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TOrderDetail_TFood_TFoodId",
                        column: x => x.TFoodId,
                        principalTable: "TFood",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TOrderDetail_TOrder_TOrderId",
                        column: x => x.TOrderId,
                        principalTable: "TOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TOrderDetail_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TOrder_TSupplierId",
                table: "TOrder",
                column: "TSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TOrder_TUserId",
                table: "TOrder",
                column: "TUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TOrderDetail_TFoodId",
                table: "TOrderDetail",
                column: "TFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_TOrderDetail_TOrderId",
                table: "TOrderDetail",
                column: "TOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TOrderDetail_TUserId",
                table: "TOrderDetail",
                column: "TUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TOrderDetail");

            migrationBuilder.DropTable(
                name: "TOrder");
        }
    }
}
