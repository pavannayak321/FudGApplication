using Microsoft.EntityFrameworkCore.Migrations;

namespace FudGApplication.Migrations
{
    public partial class Intitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurent",
                columns: table => new
                {
                    RestaurentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurent", x => x.RestaurentId);
                    table.ForeignKey(
                        name: "FK_Restaurent_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customerRestaurentFoodBridges",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    RestaurentId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerRestaurentFoodBridges", x => new { x.FoodId, x.CustomerId, x.RestaurentId });
                    table.ForeignKey(
                        name: "FK_customerRestaurentFoodBridges_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customerRestaurentFoodBridges_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customerRestaurentFoodBridges_Restaurent_RestaurentId",
                        column: x => x.RestaurentId,
                        principalTable: "Restaurent",
                        principalColumn: "RestaurentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FoodId",
                table: "Customer",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_customerRestaurentFoodBridges_CustomerId",
                table: "customerRestaurentFoodBridges",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_customerRestaurentFoodBridges_RestaurentId",
                table: "customerRestaurentFoodBridges",
                column: "RestaurentId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurent_FoodId",
                table: "Restaurent",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerRestaurentFoodBridges");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Restaurent");

            migrationBuilder.DropTable(
                name: "Food");
        }
    }
}
