using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class UPDATE_PRODUCT_REMOVE_DEFAULT_ISSELLING : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSelling",
                table: "Products",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 19, 19, 14, 40, 542, DateTimeKind.Local).AddTicks(2580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 4, 19, 59, 31, 566, DateTimeKind.Local).AddTicks(7750));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSelling",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 4, 19, 59, 31, 566, DateTimeKind.Local).AddTicks(7750),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 19, 19, 14, 40, 542, DateTimeKind.Local).AddTicks(2580));
        }
    }
}
