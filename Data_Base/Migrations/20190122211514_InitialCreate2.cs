using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Base.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Product_Pricing_Table_Retailers_product_id",
                table: "Product_Pricing_Table_Retailers",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Pricing_Table_Distributors_product_id",
                table: "Product_Pricing_Table_Distributors",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Pricing_Table_Distributors_Products_product_id",
                table: "Product_Pricing_Table_Distributors",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Pricing_Table_Retailers_Products_product_id",
                table: "Product_Pricing_Table_Retailers",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Pricing_Table_Distributors_Products_product_id",
                table: "Product_Pricing_Table_Distributors");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Pricing_Table_Retailers_Products_product_id",
                table: "Product_Pricing_Table_Retailers");

            migrationBuilder.DropIndex(
                name: "IX_Product_Pricing_Table_Retailers_product_id",
                table: "Product_Pricing_Table_Retailers");

            migrationBuilder.DropIndex(
                name: "IX_Product_Pricing_Table_Distributors_product_id",
                table: "Product_Pricing_Table_Distributors");
        }
    }
}
