using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class ADD_CUSTOMERORDERSTATEDETAILS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 39, 4, 261, DateTimeKind.Local).AddTicks(8610),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 17, 18, 53, 1, 353, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.CreateTable(
                name: "CustomerOrderStateDetails",
                columns: table => new
                {
                    OrderState = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerOrderId = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 20, 21, 39, 4, 188, DateTimeKind.Local).AddTicks(5610))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrderStateDetails", x => new { x.CustomerOrderId, x.EmployeeId, x.OrderState });
                    table.ForeignKey(
                        name: "FK_CustomerOrderStateDetails_CustomerOrders_CustomerOrderId",
                        column: x => x.CustomerOrderId,
                        principalTable: "CustomerOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrderStateDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderStateDetails_EmployeeId",
                table: "CustomerOrderStateDetails",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrderStateDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 17, 18, 53, 1, 353, DateTimeKind.Local).AddTicks(9440),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 39, 4, 261, DateTimeKind.Local).AddTicks(8610));
        }
    }
}
