using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class UPDATE_CUSTOMERPRODUCTDETAILS_ADD_COMMENT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 21, 49, 20, 335, DateTimeKind.Local).AddTicks(4918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 23, 20, 27, 38, 456, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "CustomerProductDetails",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerOrderStateDetails",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 10, 21, 49, 20, 302, DateTimeKind.Local).AddTicks(8573),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 23, 20, 27, 38, 393, DateTimeKind.Local).AddTicks(3600));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "CustomerProductDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 20, 27, 38, 456, DateTimeKind.Local).AddTicks(8140),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 10, 21, 49, 20, 335, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerOrderStateDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 20, 27, 38, 393, DateTimeKind.Local).AddTicks(3600),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 10, 21, 49, 20, 302, DateTimeKind.Local).AddTicks(8573));
        }
    }
}
