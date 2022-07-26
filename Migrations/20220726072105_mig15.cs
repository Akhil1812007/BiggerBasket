using Microsoft.EntityFrameworkCore.Migrations;

namespace BiggerBasket.Migrations
{
    public partial class mig15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_carts_CustomerEmail2",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "OrderMasters");

            migrationBuilder.DropColumn(
                name: "CustomerEmail1",
                table: "OrderMasters");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CustomerEmail1",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "CustomerEmail1",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "CustomerEmail2",
                table: "carts");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "OrderMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMasters_CustomerId",
                table: "OrderMasters",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_carts_CustomerId",
                table: "carts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_Customers_CustomerId",
                table: "carts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Customers_CustomerId",
                table: "Feedbacks",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMasters_Customers_CustomerId",
                table: "OrderMasters",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_Customers_CustomerId",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Customers_CustomerId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMasters_Customers_CustomerId",
                table: "OrderMasters");

            migrationBuilder.DropIndex(
                name: "IX_OrderMasters_CustomerId",
                table: "OrderMasters");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_carts_CustomerId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OrderMasters");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "carts");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "OrderMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail1",
                table: "OrderMasters",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail1",
                table: "Feedbacks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "carts",
                type: "nvarchar(max)",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerEmail");

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
    }
}
