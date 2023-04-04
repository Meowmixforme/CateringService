using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Catering.Migrations
{
    public partial class _6thjan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                table: "MenuFoodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId",
                table: "MenuFoodItems");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 1,
                column: "Description",
                value: "Delicious Chocolate");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 2,
                column: "Description",
                value: "Steaming Steak");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 3,
                column: "Description",
                value: "Juicy Burger");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 4,
                column: "Description",
                value: "Mouth watering Fries");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 5,
                column: "Description",
                value: "Fizzy Soda");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 6,
                column: "Description",
                value: "Hot Tea");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 7,
                column: "Description",
                value: "Warm Coffee");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                table: "MenuFoodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId",
                table: "MenuFoodItems");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 1,
                column: "Description",
                value: "Chocolate");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 2,
                column: "Description",
                value: "Steak");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 3,
                column: "Description",
                value: "Burger");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 4,
                column: "Description",
                value: "Fries");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 5,
                column: "Description",
                value: "Soda");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 6,
                column: "Description",
                value: "Tea");

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 7,
                column: "Description",
                value: "Coffee");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                table: "MenuFoodItems",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "FoodItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId",
                table: "MenuFoodItems",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
