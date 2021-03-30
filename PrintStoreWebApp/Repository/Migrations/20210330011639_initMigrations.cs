using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class initMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CustomerPasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CustomerFName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerLName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerZip = table.Column<int>(type: "int", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Prints",
                columns: table => new
                {
                    PrintID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrintTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistFName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistLName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintPrice = table.Column<double>(type: "float", nullable: false),
                    PrintImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintDecription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prints", x => x.PrintID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreZip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    PrintId = table.Column<int>(type: "int", nullable: false),
                    PrintQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => new { x.StoreId, x.PrintId });
                    table.ForeignKey(
                        name: "FK_Inventories_Prints_PrintId",
                        column: x => x.PrintId,
                        principalTable: "Prints",
                        principalColumn: "PrintID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderSubtotal = table.Column<double>(type: "float", nullable: false),
                    OrderTax = table.Column<double>(type: "float", nullable: false),
                    OrderTotalPrice = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrdersId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orderline",
                columns: table => new
                {
                    OrderNumId = table.Column<int>(type: "int", nullable: false),
                    PrintId = table.Column<int>(type: "int", nullable: false),
                    PrintQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderline", x => new { x.OrderNumId, x.PrintId });
                    table.ForeignKey(
                        name: "FK_Orderline_Orders_OrderNumId",
                        column: x => x.OrderNumId,
                        principalTable: "Orders",
                        principalColumn: "OrdersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderline_Prints_PrintId",
                        column: x => x.PrintId,
                        principalTable: "Prints",
                        principalColumn: "PrintID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_PrintId",
                table: "Inventories",
                column: "PrintId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderline_PrintId",
                table: "Orderline",
                column: "PrintId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreId",
                table: "Orders",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Orderline");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Prints");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
