using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Base.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false),
                    EntityUserMapTo_Id = table.Column<int>(nullable: false),
                    EntityUserMapTo_Name = table.Column<string>(nullable: false),
                    EntityUserMapTo_Type = table.Column<string>(nullable: false),
                    UserAccessingEntityWithPermissions = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Available_Roles",
                columns: table => new
                {
                    availablerole_id = table.Column<int>(nullable: false),
                    role_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Available_Roles", x => x.availablerole_id);
                });

            migrationBuilder.CreateTable(
                name: "Company_Types",
                columns: table => new
                {
                    Company_type_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Types", x => x.Company_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Distributor_Types",
                columns: table => new
                {
                    distributor_type_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributor_Types", x => x.distributor_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Order_Receiver",
                columns: table => new
                {
                    order_receiver_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    order_receiving_party_type = table.Column<string>(nullable: true),
                    id_of_order_receiving_party = table.Column<int>(nullable: false),
                    name_order_receiving_party = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Receiver", x => x.order_receiver_id);
                });

            migrationBuilder.CreateTable(
                name: "Order_Sender",
                columns: table => new
                {
                    order_sender_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    order_sending_party_type = table.Column<string>(nullable: true),
                    id_of_order_sending_party = table.Column<int>(nullable: false),
                    name_order_sending_party = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Sender", x => x.order_sender_id);
                });

            migrationBuilder.CreateTable(
                name: "Order_Type",
                columns: table => new
                {
                    order_type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Type", x => x.order_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    permission_id = table.Column<int>(nullable: false),
                    desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.permission_id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Category",
                columns: table => new
                {
                    product_Category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Category", x => x.product_Category_id);
                });

            migrationBuilder.CreateTable(
                name: "Retailer_Types",
                columns: table => new
                {
                    retailer_type_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retailer_Types", x => x.retailer_type_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role_Creation_Possibility",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    availablerole_id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Creation_Possibility", x => new { x.RoleId, x.availablerole_id });
                    table.ForeignKey(
                        name: "FK_Role_Creation_Possibility_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Creation_Possibility_Available_Roles_availablerole_id",
                        column: x => x.availablerole_id,
                        principalTable: "Available_Roles",
                        principalColumn: "availablerole_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    company_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    company_type_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.company_id);
                    table.ForeignKey(
                        name: "FK_Companies_Company_Types_company_type_id",
                        column: x => x.company_type_id,
                        principalTable: "Company_Types",
                        principalColumn: "Company_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distributors",
                columns: table => new
                {
                    distributor_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    distributor_type_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    gps_x = table.Column<string>(nullable: true),
                    gps_y = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributors", x => x.distributor_id);
                    table.ForeignKey(
                        name: "FK_Distributors_Distributor_Types_distributor_type_id",
                        column: x => x.distributor_type_id,
                        principalTable: "Distributor_Types",
                        principalColumn: "distributor_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    order_type_id = table.Column<int>(nullable: false),
                    order_receiver_id = table.Column<int>(nullable: false),
                    order_sender_id = table.Column<int>(nullable: false),
                    date_creation = table.Column<DateTime>(nullable: true),
                    date_requested_by = table.Column<DateTime>(nullable: true),
                    date_shipped = table.Column<DateTime>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Order_Order_Receiver_order_receiver_id",
                        column: x => x.order_receiver_id,
                        principalTable: "Order_Receiver",
                        principalColumn: "order_receiver_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Order_Sender_order_sender_id",
                        column: x => x.order_sender_id,
                        principalTable: "Order_Sender",
                        principalColumn: "order_sender_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Order_Type_order_type_id",
                        column: x => x.order_type_id,
                        principalTable: "Order_Type",
                        principalColumn: "order_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role_Permission",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    permission_id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Permission", x => new { x.RoleId, x.permission_id });
                    table.ForeignKey(
                        name: "FK_Role_Permission_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Permission_Permissions_permission_id",
                        column: x => x.permission_id,
                        principalTable: "Permissions",
                        principalColumn: "permission_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retailers",
                columns: table => new
                {
                    retailer_id = table.Column<int>(nullable: false),
                    retailer_type_id = table.Column<int>(nullable: false),
                    zone_id = table.Column<int>(nullable: false),
                    city_id = table.Column<int>(nullable: false),
                    quater_id = table.Column<int>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    picture1 = table.Column<string>(nullable: true),
                    picture2 = table.Column<string>(nullable: true),
                    gps_x = table.Column<string>(nullable: true),
                    gps_y = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retailers", x => x.retailer_id);
                    table.ForeignKey(
                        name: "FK_Retailers_Retailer_Types_retailer_type_id",
                        column: x => x.retailer_type_id,
                        principalTable: "Retailer_Types",
                        principalColumn: "retailer_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company_Contact",
                columns: table => new
                {
                    company_contact_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    mobile = table.Column<string>(nullable: true),
                    company_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Contact", x => x.company_contact_id);
                    table.ForeignKey(
                        name: "FK_Company_Contact_Companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    unitprice = table.Column<double>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    image_1 = table.Column<string>(nullable: true),
                    image_2 = table.Column<string>(nullable: true),
                    product_Category_id = table.Column<int>(nullable: false),
                    company_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Product_Companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Product_Category_product_Category_id",
                        column: x => x.product_Category_id,
                        principalTable: "Product_Category",
                        principalColumn: "product_Category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distributor_Companies",
                columns: table => new
                {
                    distributor_id = table.Column<int>(nullable: false),
                    company_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributor_Companies", x => new { x.distributor_id, x.company_id });
                    table.ForeignKey(
                        name: "FK_Distributor_Companies_Companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Distributor_Companies_Distributors_distributor_id",
                        column: x => x.distributor_id,
                        principalTable: "Distributors",
                        principalColumn: "distributor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distributor_Retailers",
                columns: table => new
                {
                    distributor_id = table.Column<int>(nullable: false),
                    retailer_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributor_Retailers", x => new { x.distributor_id, x.retailer_id });
                    table.ForeignKey(
                        name: "FK_Distributor_Retailers_Distributors_distributor_id",
                        column: x => x.distributor_id,
                        principalTable: "Distributors",
                        principalColumn: "distributor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Distributor_Retailers_Retailers_retailer_id",
                        column: x => x.retailer_id,
                        principalTable: "Retailers",
                        principalColumn: "retailer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retailer_Disponibilities",
                columns: table => new
                {
                    retailer_disponibility_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    retailer_id = table.Column<int>(nullable: false),
                    opening_closing_id = table.Column<int>(nullable: false),
                    day = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retailer_Disponibilities", x => x.retailer_disponibility_id);
                    table.ForeignKey(
                        name: "FK_Retailer_Disponibilities_Retailers_retailer_id",
                        column: x => x.retailer_id,
                        principalTable: "Retailers",
                        principalColumn: "retailer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Detail",
                columns: table => new
                {
                    order_detail_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(nullable: false),
                    order_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Detail", x => x.order_detail_id);
                    table.ForeignKey(
                        name: "FK_Order_Detail_Order_order_id",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Detail_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opening_Closings",
                columns: table => new
                {
                    opening_closing_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    retailer_disponibility_id = table.Column<int>(nullable: false),
                    opening_time = table.Column<DateTime>(nullable: false),
                    closing_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opening_Closings", x => x.opening_closing_id);
                    table.ForeignKey(
                        name: "FK_Opening_Closings_Retailer_Disponibilities_retailer_disponibility_id",
                        column: x => x.retailer_disponibility_id,
                        principalTable: "Retailer_Disponibilities",
                        principalColumn: "retailer_disponibility_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_company_type_id",
                table: "Companies",
                column: "company_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Contact_company_id",
                table: "Company_Contact",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Distributor_Companies_company_id",
                table: "Distributor_Companies",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Distributor_Retailers_retailer_id",
                table: "Distributor_Retailers",
                column: "retailer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_distributor_type_id",
                table: "Distributors",
                column: "distributor_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Opening_Closings_retailer_disponibility_id",
                table: "Opening_Closings",
                column: "retailer_disponibility_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_order_receiver_id",
                table: "Order",
                column: "order_receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_order_sender_id",
                table: "Order",
                column: "order_sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_order_type_id",
                table: "Order",
                column: "order_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_order_id",
                table: "Order_Detail",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_product_id",
                table: "Order_Detail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_company_id",
                table: "Product",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_product_Category_id",
                table: "Product",
                column: "product_Category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Retailer_Disponibilities_retailer_id",
                table: "Retailer_Disponibilities",
                column: "retailer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Retailers_retailer_type_id",
                table: "Retailers",
                column: "retailer_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Creation_Possibility_availablerole_id",
                table: "Role_Creation_Possibility",
                column: "availablerole_id");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permission_permission_id",
                table: "Role_Permission",
                column: "permission_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Company_Contact");

            migrationBuilder.DropTable(
                name: "Distributor_Companies");

            migrationBuilder.DropTable(
                name: "Distributor_Retailers");

            migrationBuilder.DropTable(
                name: "Opening_Closings");

            migrationBuilder.DropTable(
                name: "Order_Detail");

            migrationBuilder.DropTable(
                name: "Role_Creation_Possibility");

            migrationBuilder.DropTable(
                name: "Role_Permission");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Distributors");

            migrationBuilder.DropTable(
                name: "Retailer_Disponibilities");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Available_Roles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Distributor_Types");

            migrationBuilder.DropTable(
                name: "Retailers");

            migrationBuilder.DropTable(
                name: "Order_Receiver");

            migrationBuilder.DropTable(
                name: "Order_Sender");

            migrationBuilder.DropTable(
                name: "Order_Type");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Product_Category");

            migrationBuilder.DropTable(
                name: "Retailer_Types");

            migrationBuilder.DropTable(
                name: "Company_Types");
        }
    }
}
