using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCosmetic.Migrations
{
    public partial class ShopCart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ShoppingCartItem");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ShoppingCartItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShoppingCartItem");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "ShoppingCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
