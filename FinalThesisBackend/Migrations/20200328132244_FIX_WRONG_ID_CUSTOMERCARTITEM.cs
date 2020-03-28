using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalThesisBackend.Migrations
{
    public partial class FIX_WRONG_ID_CUSTOMERCARTITEM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCartItems_ProductDetails_ProductDetailsId",
                table: "CustomerCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCartItems",
                table: "CustomerCartItems");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDetailsId",
                table: "CustomerCartItems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCartItems",
                table: "CustomerCartItems",
                columns: new[] { "CustomerId", "ProductDetailsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCartItems_ProductDetails_ProductDetailsId",
                table: "CustomerCartItems",
                column: "ProductDetailsId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCartItems_ProductDetails_ProductDetailsId",
                table: "CustomerCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCartItems",
                table: "CustomerCartItems");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDetailsId",
                table: "CustomerCartItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCartItems",
                table: "CustomerCartItems",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCartItems_ProductDetails_ProductDetailsId",
                table: "CustomerCartItems",
                column: "ProductDetailsId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
