using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Catering.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                table: "MenuFoodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId",
                table: "MenuFoodItems");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                table: "MenuFoodItems",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "FoodItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId",
                table: "MenuFoodItems",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                table: "MenuFoodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId",
                table: "MenuFoodItems");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                table: "MenuFoodItems",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "FoodItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId",
                table: "MenuFoodItems",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId");
        }
    }
}
