using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class UPDATE_CATEGORY_ADD_SORTORDER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 4, 19, 23, 35, 968, DateTimeKind.Local).AddTicks(1670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 2, 17, 56, 6, 283, DateTimeKind.Local).AddTicks(9670));

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ProductCategories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ProductCategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 2, 17, 56, 6, 283, DateTimeKind.Local).AddTicks(9670),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 4, 19, 23, 35, 968, DateTimeKind.Local).AddTicks(1670));
        }
    }
}
