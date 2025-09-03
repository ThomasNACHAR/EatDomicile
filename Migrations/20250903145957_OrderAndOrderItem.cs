using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatDomicile.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergens_Burgers_BurgerId",
                table: "Allergens");

            migrationBuilder.DropForeignKey(
                name: "FK_Allergens_Drinks_DrinkId",
                table: "Allergens");

            migrationBuilder.DropForeignKey(
                name: "FK_Allergens_Pastas_PastaId",
                table: "Allergens");

            migrationBuilder.DropForeignKey(
                name: "FK_Allergens_Pizzas_PizzaId",
                table: "Allergens");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Burgers_BurgerId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Pastas_PastaId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Pizzas_PizzaId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Doughs_DoughId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "Burgers");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Pastas");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_BurgerId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_PastaId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_PizzaId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Allergens_BurgerId",
                table: "Allergens");

            migrationBuilder.DropIndex(
                name: "IX_Allergens_DrinkId",
                table: "Allergens");

            migrationBuilder.DropIndex(
                name: "IX_Allergens_PastaId",
                table: "Allergens");

            migrationBuilder.DropIndex(
                name: "IX_Allergens_PizzaId",
                table: "Allergens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "BurgerId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "PastaId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "BurgerId",
                table: "Allergens");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "Allergens");

            migrationBuilder.DropColumn(
                name: "PastaId",
                table: "Allergens");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "Allergens");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_DoughId",
                table: "Product",
                newName: "IX_Product_DoughId");

            migrationBuilder.AlterColumn<bool>(
                name: "Vegetarian",
                table: "Product",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoughId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Product",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Fizzy",
                table: "Product",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AllergenProduct",
                columns: table => new
                {
                    AllergensId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergenProduct", x => new { x.AllergensId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_AllergenProduct_Allergens_AllergensId",
                        column: x => x.AllergensId,
                        principalTable: "Allergens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergenProduct_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BurgerIngredient",
                columns: table => new
                {
                    BurgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurgerIngredient", x => new { x.BurgerId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_BurgerIngredient_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BurgerIngredient_Product_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientPasta",
                columns: table => new
                {
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientPasta", x => new { x.IngredientsId, x.PastasId });
                    table.ForeignKey(
                        name: "FK_IngredientPasta_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientPasta_Product_PastasId",
                        column: x => x.PastasId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientPizza",
                columns: table => new
                {
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientPizza", x => new { x.IngredientsId, x.PizzasId });
                    table.ForeignKey(
                        name: "FK_IngredientPizza_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientPizza_Product_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergenProduct_ProductsId",
                table: "AllergenProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_BurgerIngredient_IngredientsId",
                table: "BurgerIngredient",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPasta_PastasId",
                table: "IngredientPasta",
                column: "PastasId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPizza_PizzasId",
                table: "IngredientPizza",
                column: "PizzasId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Doughs_DoughId",
                table: "Product",
                column: "DoughId",
                principalTable: "Doughs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Doughs_DoughId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "AllergenProduct");

            migrationBuilder.DropTable(
                name: "BurgerIngredient");

            migrationBuilder.DropTable(
                name: "IngredientPasta");

            migrationBuilder.DropTable(
                name: "IngredientPizza");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Fizzy",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Pizzas");

            migrationBuilder.RenameIndex(
                name: "IX_Product_DoughId",
                table: "Pizzas",
                newName: "IX_Pizzas_DoughId");

            migrationBuilder.AddColumn<Guid>(
                name: "BurgerId",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PastaId",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PizzaId",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BurgerId",
                table: "Allergens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DrinkId",
                table: "Allergens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PastaId",
                table: "Allergens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PizzaId",
                table: "Allergens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Vegetarian",
                table: "Pizzas",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DoughId",
                table: "Pizzas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Burgers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KCal = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Vegetarian = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burgers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fizzy = table.Column<bool>(type: "bit", nullable: false),
                    KCal = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pastas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KCal = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vegetarian = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_BurgerId",
                table: "Ingredients",
                column: "BurgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_PastaId",
                table: "Ingredients",
                column: "PastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_PizzaId",
                table: "Ingredients",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_BurgerId",
                table: "Allergens",
                column: "BurgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_DrinkId",
                table: "Allergens",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_PastaId",
                table: "Allergens",
                column: "PastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_PizzaId",
                table: "Allergens",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergens_Burgers_BurgerId",
                table: "Allergens",
                column: "BurgerId",
                principalTable: "Burgers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergens_Drinks_DrinkId",
                table: "Allergens",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergens_Pastas_PastaId",
                table: "Allergens",
                column: "PastaId",
                principalTable: "Pastas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergens_Pizzas_PizzaId",
                table: "Allergens",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Burgers_BurgerId",
                table: "Ingredients",
                column: "BurgerId",
                principalTable: "Burgers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Pastas_PastaId",
                table: "Ingredients",
                column: "PastaId",
                principalTable: "Pastas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Pizzas_PizzaId",
                table: "Ingredients",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Doughs_DoughId",
                table: "Pizzas",
                column: "DoughId",
                principalTable: "Doughs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
