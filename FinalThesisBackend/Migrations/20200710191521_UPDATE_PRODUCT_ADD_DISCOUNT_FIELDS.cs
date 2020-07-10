using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class UPDATE_PRODUCT_ADD_DISCOUNT_FIELDS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DiscountAmount",
                table: "Products",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscount",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 2, 15, 21, 171, DateTimeKind.Local).AddTicks(9523),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 21, 49, 20, 335, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerOrderStateDetails",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 11, 2, 15, 21, 149, DateTimeKind.Local).AddTicks(163),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 10, 21, 49, 20, 302, DateTimeKind.Local).AddTicks(8573));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDiscount",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 21, 49, 20, 335, DateTimeKind.Local).AddTicks(4918),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 2, 15, 21, 171, DateTimeKind.Local).AddTicks(9523));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerOrderStateDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 21, 49, 20, 302, DateTimeKind.Local).AddTicks(8573),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 11, 2, 15, 21, 149, DateTimeKind.Local).AddTicks(163));
        }
    }
}
