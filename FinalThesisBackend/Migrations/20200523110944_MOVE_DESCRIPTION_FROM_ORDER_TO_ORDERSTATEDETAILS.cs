using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class MOVE_DESCRIPTION_FROM_ORDER_TO_ORDERSTATEDETAILS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerOrders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 18, 9, 44, 232, DateTimeKind.Local).AddTicks(2510),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 39, 4, 261, DateTimeKind.Local).AddTicks(8610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerOrderStateDetails",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 18, 9, 44, 160, DateTimeKind.Local).AddTicks(1800),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 39, 4, 188, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomerOrderStateDetails",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerOrderStateDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 39, 4, 261, DateTimeKind.Local).AddTicks(8610),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 18, 9, 44, 232, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerOrderStateDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 39, 4, 188, DateTimeKind.Local).AddTicks(5610),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 18, 9, 44, 160, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomerOrders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
