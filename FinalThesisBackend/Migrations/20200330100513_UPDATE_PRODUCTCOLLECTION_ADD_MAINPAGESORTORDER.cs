using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class UPDATE_PRODUCTCOLLECTION_ADD_MAINPAGESORTORDER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "ProductCollectionDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 30, 17, 5, 12, 476, DateTimeKind.Local).AddTicks(4530),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 29, 19, 1, 15, 134, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.AddColumn<int>(
                name: "MainPageSortOrder",
                table: "ProductCollections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ProductCollectionDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPageSortOrder",
                table: "ProductCollections");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ProductCollectionDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 29, 19, 1, 15, 134, DateTimeKind.Local).AddTicks(3050),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 30, 17, 5, 12, 476, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ProductCollectionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
