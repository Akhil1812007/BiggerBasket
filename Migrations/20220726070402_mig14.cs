using Microsoft.EntityFrameworkCore.Migrations;

namespace BiggerBasket.Migrations
{
    public partial class mig14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_Customers_CustomerEmail",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Customers_CustomerEmail",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMasters_Customers_CustomerEmail",
                table: "OrderMasters");

            migrationBuilder.DropIndex(
                name: "IX_OrderMasters_CustomerEmail",
                table: "OrderMasters");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_CustomerEmail",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_carts_CustomerEmail",
                table: "carts");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail1",
                table: "OrderMasters",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail1",
                table: "Feedbacks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail1",
                table: "carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail2",
                table: "carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderMasters_CustomerEmail1",
                table: "OrderMasters",
                column: "CustomerEmail1");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerEmail1",
                table: "Feedbacks",
                column: "CustomerEmail1");

            migrationBuilder.CreateIndex(
                name: "IX_carts_CustomerEmail2",
                table: "carts",
                column: "CustomerEmail2");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_Customers_CustomerEmail2",
                table: "carts",
                column: "CustomerEmail2",
                principalTable: "Customers",
                principalColumn: "CustomerEmail",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Customers_CustomerEmail1",
                table: "Feedbacks",
                column: "CustomerEmail1",
                principalTable: "Customers",
                principalColumn: "CustomerEmail",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMasters_Customers_CustomerEmail1",
                table: "OrderMasters",
                column: "CustomerEmail1",
                principalTable: "Customers",
                principalColumn: "CustomerEmail",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_Customers_CustomerEmail2",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Customers_CustomerEmail1",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMasters_Customers_CustomerEmail1",
                table: "OrderMasters");

            migrationBuilder.DropIndex(
                name: "IX_OrderMasters_CustomerEmail1",
                table: "OrderMasters");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_CustomerEmail1",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_carts_CustomerEmail2",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "CustomerEmail1",
                table: "OrderMasters");

            migrationBuilder.DropColumn(
                name: "CustomerEmail1",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CustomerEmail1",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "CustomerEmail2",
                table: "carts");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMasters_CustomerEmail",
                table: "OrderMasters",
                column: "CustomerEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerEmail",
                table: "Feedbacks",
                column: "CustomerEmail");

            migrationBuilder.CreateIndex(
                name: "IX_carts_CustomerEmail",
                table: "carts",
                column: "CustomerEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_Customers_CustomerEmail",
                table: "carts",
                column: "CustomerEmail",
                principalTable: "Customers",
                principalColumn: "CustomerEmail",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Customers_CustomerEmail",
                table: "Feedbacks",
                column: "CustomerEmail",
                principalTable: "Customers",
                principalColumn: "CustomerEmail",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMasters_Customers_CustomerEmail",
                table: "OrderMasters",
                column: "CustomerEmail",
                principalTable: "Customers",
                principalColumn: "CustomerEmail",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
