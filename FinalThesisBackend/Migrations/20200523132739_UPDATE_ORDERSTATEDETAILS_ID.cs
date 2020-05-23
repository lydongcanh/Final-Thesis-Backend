using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class UPDATE_ORDERSTATEDETAILS_ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderStateDetails_Employees_EmployeeId",
                table: "CustomerOrderStateDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerOrderStateDetails",
                table: "CustomerOrderStateDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 20, 27, 38, 456, DateTimeKind.Local).AddTicks(8140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 23, 18, 9, 44, 232, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerOrderStateDetails",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 20, 27, 38, 393, DateTimeKind.Local).AddTicks(3600),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 23, 18, 9, 44, 160, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "CustomerOrderStateDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerOrderStateDetails",
                table: "CustomerOrderStateDetails",
                columns: new[] { "CustomerOrderId", "OrderState" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderStateDetails_Employees_EmployeeId",
                table: "CustomerOrderStateDetails",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrderStateDetails_Employees_EmployeeId",
                table: "CustomerOrderStateDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerOrderStateDetails",
                table: "CustomerOrderStateDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 18, 9, 44, 232, DateTimeKind.Local).AddTicks(2510),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 20, 27, 38, 456, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "CustomerOrderStateDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerOrderStateDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 18, 9, 44, 160, DateTimeKind.Local).AddTicks(1800),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 20, 27, 38, 393, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerOrderStateDetails",
                table: "CustomerOrderStateDetails",
                columns: new[] { "CustomerOrderId", "EmployeeId", "OrderState" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrderStateDetails_Employees_EmployeeId",
                table: "CustomerOrderStateDetails",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
