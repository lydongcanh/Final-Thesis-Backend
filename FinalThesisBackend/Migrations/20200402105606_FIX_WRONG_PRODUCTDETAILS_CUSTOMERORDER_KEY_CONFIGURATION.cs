using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class FIX_WRONG_PRODUCTDETAILS_CUSTOMERORDER_KEY_CONFIGURATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetails_ProductDetails_CustomerOrderId",
                table: "CustomerOrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 2, 17, 56, 6, 283, DateTimeKind.Local).AddTicks(9670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 1, 19, 54, 13, 351, DateTimeKind.Local).AddTicks(5150));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetails_ProductDetails_ProductDetailsId",
                table: "CustomerOrderDetails",
                column: "ProductDetailsId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetails_ProductDetails_ProductDetailsId",
                table: "CustomerOrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 1, 19, 54, 13, 351, DateTimeKind.Local).AddTicks(5150),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 2, 17, 56, 6, 283, DateTimeKind.Local).AddTicks(9670));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetails_ProductDetails_CustomerOrderId",
                table: "CustomerOrderDetails",
                column: "CustomerOrderId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
