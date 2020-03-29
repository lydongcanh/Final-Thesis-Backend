using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class ADD_PRODUCTCOLLECTION_PRODUCTCOLLECTIONDETAILS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCollections",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 29, 19, 1, 15, 134, DateTimeKind.Local).AddTicks(3050)),
                    ShowOnMainPage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCollections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCollectionDetails",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    ProductCollectionId = table.Column<string>(nullable: false),
                    ShowOnMainPage = table.Column<bool>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCollectionDetails", x => new { x.ProductId, x.ProductCollectionId });
                    table.ForeignKey(
                        name: "FK_ProductCollectionDetails_ProductCollections_ProductCollectionId",
                        column: x => x.ProductCollectionId,
                        principalTable: "ProductCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCollectionDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCollectionDetails_ProductCollectionId",
                table: "ProductCollectionDetails",
                column: "ProductCollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCollectionDetails");

            migrationBuilder.DropTable(
                name: "ProductCollections");
        }
    }
}
