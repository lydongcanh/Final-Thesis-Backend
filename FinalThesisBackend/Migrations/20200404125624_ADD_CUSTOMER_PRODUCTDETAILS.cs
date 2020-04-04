using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class ADD_CUSTOMER_PRODUCTDETAILS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 4, 19, 56, 23, 801, DateTimeKind.Local).AddTicks(2770),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 4, 19, 23, 35, 968, DateTimeKind.Local).AddTicks(1670));

            migrationBuilder.CreateTable(
                name: "CustomerProductDetails",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    ProductId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    Liked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProductDetails", x => new { x.CustomerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CustomerProductDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProductDetails_ProductId",
                table: "CustomerProductDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProductDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 4, 19, 23, 35, 968, DateTimeKind.Local).AddTicks(1670),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 4, 19, 56, 23, 801, DateTimeKind.Local).AddTicks(2770));
        }
    }
}
