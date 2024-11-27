using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryStoreShopListApi.Migrations
{
    /// <inheritdoc />
    public partial class Nova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_product_shoplistId",
                table: "product",
                column: "shoplistId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_shoplist_shoplistId",
                table: "product",
                column: "shoplistId",
                principalTable: "shoplist",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_shoplist_shoplistId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_shoplistId",
                table: "product");
        }
    }
}
