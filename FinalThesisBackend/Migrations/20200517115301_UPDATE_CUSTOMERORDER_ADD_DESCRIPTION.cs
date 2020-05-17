using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class UPDATE_CUSTOMERORDER_ADD_DESCRIPTION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 17, 18, 53, 1, 353, DateTimeKind.Local).AddTicks(9440),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 16, 22, 30, 43, 129, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomerOrders",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerOrders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 16, 22, 30, 43, 129, DateTimeKind.Local).AddTicks(2930),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 17, 18, 53, 1, 353, DateTimeKind.Local).AddTicks(9440));
        }
    }
}
