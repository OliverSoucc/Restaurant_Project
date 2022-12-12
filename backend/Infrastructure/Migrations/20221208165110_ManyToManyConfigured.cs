using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyConfigured : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Dishes_DishesId",
                table: "DishIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Ingredients_IngredientsId",
                table: "DishIngredient");

            migrationBuilder.RenameColumn(
                name: "IngredientsId",
                table: "DishIngredient",
                newName: "IngredientId");

            migrationBuilder.RenameColumn(
                name: "DishesId",
                table: "DishIngredient",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredient_IngredientsId",
                table: "DishIngredient",
                newName: "IX_DishIngredient_IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Dishes_DishId",
                table: "DishIngredient",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Ingredients_IngredientId",
                table: "DishIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Dishes_DishId",
                table: "DishIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Ingredients_IngredientId",
                table: "DishIngredient");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "DishIngredient",
                newName: "IngredientsId");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "DishIngredient",
                newName: "DishesId");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredient_IngredientId",
                table: "DishIngredient",
                newName: "IX_DishIngredient_IngredientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Dishes_DishesId",
                table: "DishIngredient",
                column: "DishesId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Ingredients_IngredientsId",
                table: "DishIngredient",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
