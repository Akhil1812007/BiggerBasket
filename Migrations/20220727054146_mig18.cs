using Microsoft.EntityFrameworkCore.Migrations;

namespace BiggerBasket.Migrations
{
    public partial class mig18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderMasters_OrderMasterId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderMasterId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderMasterId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "OrderMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMasters_OrderDetailId",
                table: "OrderMasters",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMasters_OrderDetails_OrderDetailId",
                table: "OrderMasters",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMasters_OrderDetails_OrderDetailId",
                table: "OrderMasters");

            migrationBuilder.DropIndex(
                name: "IX_OrderMasters_OrderDetailId",
                table: "OrderMasters");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "OrderMasters");

            migrationBuilder.AddColumn<int>(
                name: "OrderMasterId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderMasterId",
                table: "OrderDetails",
                column: "OrderMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderMasters_OrderMasterId",
                table: "OrderDetails",
                column: "OrderMasterId",
                principalTable: "OrderMasters",
                principalColumn: "OrderMasterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
