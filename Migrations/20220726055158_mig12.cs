using Microsoft.EntityFrameworkCore.Migrations;

namespace BiggerBasket.Migrations
{
    public partial class mig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
             

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "OrderMasters",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Feedbacks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "carts",
                type: "nvarchar(450)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
