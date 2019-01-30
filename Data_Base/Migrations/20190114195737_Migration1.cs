using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Base.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Detail_Product_product_id",
                table: "Order_Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Companies_company_id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product_Category_product_Category_id",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Category",
                table: "Product_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product_Category",
                newName: "Product_Categories");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "unitprice",
                table: "Products",
                newName: "unitprice_standard_for_retailer");

            migrationBuilder.RenameIndex(
                name: "IX_Product_product_Category_id",
                table: "Products",
                newName: "IX_Products_product_Category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_company_id",
                table: "Products",
                newName: "IX_Products_company_id");

            migrationBuilder.AddColumn<string>(
                name: "product_code",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "unit",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "unitprice_standard_for_distributor",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Categories",
                table: "Product_Categories",
                column: "product_Category_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "product_id");

            migrationBuilder.CreateTable(
                name: "Product_Pricing_Table_Distributors",
                columns: table => new
                {
                    product_pricing_table_distributor_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(nullable: false),
                    distributor_id = table.Column<int>(nullable: false),
                    company_id = table.Column<int>(nullable: false),
                    agree_unitpricing = table.Column<double>(nullable: false),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Pricing_Table_Distributors", x => x.product_pricing_table_distributor_id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Pricing_Table_Retailers",
                columns: table => new
                {
                    product_pricing_table_retailer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(nullable: false),
                    distributor_id = table.Column<int>(nullable: false),
                    retailer_id = table.Column<int>(nullable: false),
                    agree_unitpricing = table.Column<double>(nullable: false),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Pricing_Table_Retailers", x => x.product_pricing_table_retailer_id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Detail_Products_product_id",
                table: "Order_Detail",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_company_id",
                table: "Products",
                column: "company_id",
                principalTable: "Companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Product_Categories_product_Category_id",
                table: "Products",
                column: "product_Category_id",
                principalTable: "Product_Categories",
                principalColumn: "product_Category_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Detail_Products_product_id",
                table: "Order_Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_company_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Product_Categories_product_Category_id",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Product_Pricing_Table_Distributors");

            migrationBuilder.DropTable(
                name: "Product_Pricing_Table_Retailers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Categories",
                table: "Product_Categories");

            migrationBuilder.DropColumn(
                name: "product_code",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "unit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "unitprice_standard_for_distributor",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Product_Categories",
                newName: "Product_Category");

            migrationBuilder.RenameColumn(
                name: "unitprice_standard_for_retailer",
                table: "Product",
                newName: "unitprice");

            migrationBuilder.RenameIndex(
                name: "IX_Products_product_Category_id",
                table: "Product",
                newName: "IX_Product_product_Category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_company_id",
                table: "Product",
                newName: "IX_Product_company_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Category",
                table: "Product_Category",
                column: "product_Category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Detail_Product_product_id",
                table: "Order_Detail",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Companies_company_id",
                table: "Product",
                column: "company_id",
                principalTable: "Companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Product_Category_product_Category_id",
                table: "Product",
                column: "product_Category_id",
                principalTable: "Product_Category",
                principalColumn: "product_Category_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
