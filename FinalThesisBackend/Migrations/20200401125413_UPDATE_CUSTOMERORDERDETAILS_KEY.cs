using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class UPDATE_CUSTOMERORDERDETAILS_KEY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetails_CustomerOrders_CustomerOrderId",
                table: "CustomerOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetails_ProductDetails_CustomerOrderId",
                table: "CustomerOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerOrderDetails",
                table: "CustomerOrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 1, 19, 54, 13, 351, DateTimeKind.Local).AddTicks(5150),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 1, 19, 35, 7, 296, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.AlterColumn<string>(
                name: "ProductDetailsId",
                table: "CustomerOrderDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerOrderId",
                table: "CustomerOrderDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "CustomerOrderDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerOrderDetails",
                table: "CustomerOrderDetails",
                columns: new[] { "ProductDetailsId", "CustomerOrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetails_CustomerOrders_CustomerOrderId",
                table: "CustomerOrderDetails",
                column: "CustomerOrderId",
                principalTable: "CustomerOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetails_ProductDetails_CustomerOrderId",
                table: "CustomerOrderDetails",
                column: "CustomerOrderId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetails_CustomerOrders_CustomerOrderId",
                table: "CustomerOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderDetails_ProductDetails_CustomerOrderId",
                table: "CustomerOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerOrderDetails",
                table: "CustomerOrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 1, 19, 35, 7, 296, DateTimeKind.Local).AddTicks(5550),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 1, 19, 54, 13, 351, DateTimeKind.Local).AddTicks(5150));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "CustomerOrderDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerOrderId",
                table: "CustomerOrderDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProductDetailsId",
                table: "CustomerOrderDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerOrderDetails",
                table: "CustomerOrderDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetails_CustomerOrders_CustomerOrderId",
                table: "CustomerOrderDetails",
                column: "CustomerOrderId",
                principalTable: "CustomerOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderDetails_ProductDetails_CustomerOrderId",
                table: "CustomerOrderDetails",
                column: "CustomerOrderId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
