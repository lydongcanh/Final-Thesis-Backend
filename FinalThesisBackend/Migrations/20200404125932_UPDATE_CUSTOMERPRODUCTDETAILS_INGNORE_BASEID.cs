using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class UPDATE_CUSTOMERPRODUCTDETAILS_INGNORE_BASEID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CustomerProductDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 4, 19, 59, 31, 566, DateTimeKind.Local).AddTicks(7750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 4, 19, 56, 23, 801, DateTimeKind.Local).AddTicks(2770));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 4, 19, 56, 23, 801, DateTimeKind.Local).AddTicks(2770),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 4, 19, 59, 31, 566, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "CustomerProductDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
