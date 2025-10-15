using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeBook.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Category", "CreatedAt", "ImagePath", "Ingredients", "OwnerId", "Steps", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Main Dish", new DateTime(2025, 10, 4, 23, 46, 19, 440, DateTimeKind.Utc).AddTicks(3063), "/images/recipes/jollof.jpg", "2 cups rice\n1 can tomato paste\n2 cups chicken stock\n1 onion\n2 tomatoes\n1 tsp salt\n1 tsp pepper\n1 tsp curry powder\n2 tbsp oil", null, "1. Blend tomatoes and onion.\n2. Heat oil and fry tomato paste for 5 minutes.\n3. Add blended mix, seasoning, and stock.\n4. Add rice and simmer until cooked.", "Ghanaian Jollof Rice", new DateTime(2025, 10, 6, 23, 46, 19, 440, DateTimeKind.Utc).AddTicks(5306) },
                    { 2, "Traditional", new DateTime(2025, 10, 7, 23, 46, 19, 440, DateTimeKind.Utc).AddTicks(6385), "/images/recipes/redred.jpg", "3 ripe plantains\n2 cups black-eyed beans\n1 onion\n1 cup palm oil\nSalt to taste\nPepper to taste", null, "1. Boil beans until soft.\n2. Prepare palm oil sauce with onions and pepper.\n3. Mix beans with sauce.\n4. Fry sliced plantains until golden brown.", "Fried Plantain with Beans (Red Red)", new DateTime(2025, 10, 9, 23, 46, 19, 440, DateTimeKind.Utc).AddTicks(6389) },
                    { 3, "Soup", new DateTime(2025, 10, 8, 23, 46, 19, 440, DateTimeKind.Utc).AddTicks(6394), "/images/recipes/lightsoup.jpg", "1 whole chicken\n4 tomatoes\n1 onion\n2 scotch bonnet peppers\n1 tbsp tomato paste\nSalt and spices to taste", null, "1. Season chicken and boil for 10 mins.\n2. Blend tomatoes, onion, and pepper.\n3. Add blend and tomato paste to chicken.\n4. Simmer until thick and chicken is tender.", "Chicken Light Soup", new DateTime(2025, 10, 10, 23, 46, 19, 440, DateTimeKind.Utc).AddTicks(6395) },
                    { 4, "Vegetarian", new DateTime(2025, 10, 11, 23, 46, 19, 440, DateTimeKind.Utc).AddTicks(6399), "/images/recipes/stirfry.jpg", "1 cup chopped carrots\n1 bell pepper\n1 onion\n1 cup broccoli\n2 tbsp soy sauce\n1 tbsp oil\nSalt to taste", null, "1. Heat oil in pan.\n2. Add onion and stir for 1 min.\n3. Add vegetables and soy sauce.\n4. Stir-fry for 5 mins and serve warm.", "Vegetable Stir-Fry", new DateTime(2025, 10, 13, 23, 46, 19, 440, DateTimeKind.Utc).AddTicks(6400) },
                    { 5, "Dessert", new DateTime(2025, 10, 12, 23, 46, 19, 440, DateTimeKind.Utc).AddTicks(6403), "/images/recipes/chocolatecake.jpg", "2 cups flour\n1 cup sugar\n1/2 cup cocoa powder\n2 eggs\n1 cup milk\n1/2 cup butter\n1 tsp baking powder", null, "1. Preheat oven to 180°C.\n2. Mix dry ingredients.\n3. Add wet ingredients and blend well.\n4. Pour into pan and bake 30–35 mins.", "Chocolate Cake", new DateTime(2025, 10, 14, 23, 46, 19, 440, DateTimeKind.Utc).AddTicks(6404) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
