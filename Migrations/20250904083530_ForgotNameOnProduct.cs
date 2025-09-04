using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatDomicile.Migrations
{
    /// <inheritdoc />
    public partial class ForgotNameOnProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllergenProduct_Product_ProductsId",
                table: "AllergenProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BurgerIngredient_Product_BurgerId",
                table: "BurgerIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientPasta_Product_PastasId",
                table: "IngredientPasta");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientPizza_Product_PizzasId",
                table: "IngredientPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Product_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Doughs_DoughId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_DoughId",
                table: "Products",
                newName: "IX_Products_DoughId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllergenProduct_Products_ProductsId",
                table: "AllergenProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BurgerIngredient_Products_BurgerId",
                table: "BurgerIngredient",
                column: "BurgerId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientPasta_Products_PastasId",
                table: "IngredientPasta",
                column: "PastasId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientPizza_Products_PizzasId",
                table: "IngredientPizza",
                column: "PizzasId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Doughs_DoughId",
                table: "Products",
                column: "DoughId",
                principalTable: "Doughs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllergenProduct_Products_ProductsId",
                table: "AllergenProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BurgerIngredient_Products_BurgerId",
                table: "BurgerIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientPasta_Products_PastasId",
                table: "IngredientPasta");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientPizza_Products_PizzasId",
                table: "IngredientPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Doughs_DoughId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_DoughId",
                table: "Product",
                newName: "IX_Product_DoughId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllergenProduct_Product_ProductsId",
                table: "AllergenProduct",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BurgerIngredient_Product_BurgerId",
                table: "BurgerIngredient",
                column: "BurgerId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientPasta_Product_PastasId",
                table: "IngredientPasta",
                column: "PastasId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientPizza_Product_PizzasId",
                table: "IngredientPizza",
                column: "PizzasId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Product_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Doughs_DoughId",
                table: "Product",
                column: "DoughId",
                principalTable: "Doughs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
