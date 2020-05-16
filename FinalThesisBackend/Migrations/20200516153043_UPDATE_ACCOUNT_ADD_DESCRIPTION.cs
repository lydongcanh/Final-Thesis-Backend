using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class UPDATE_ACCOUNT_ADD_DESCRIPTION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 16, 22, 30, 43, 129, DateTimeKind.Local).AddTicks(2930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 19, 19, 14, 40, 542, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Accounts",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Accounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 19, 19, 14, 40, 542, DateTimeKind.Local).AddTicks(2580),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 16, 22, 30, 43, 129, DateTimeKind.Local).AddTicks(2930));
        }
    }
}
