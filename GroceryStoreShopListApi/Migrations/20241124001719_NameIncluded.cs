using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryStoreShopListApi.Migrations
{
    /// <inheritdoc />
    public partial class NameIncluded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "listName",
                table: "shoplist",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "listName",
                table: "shoplist");
        }
    }
}
