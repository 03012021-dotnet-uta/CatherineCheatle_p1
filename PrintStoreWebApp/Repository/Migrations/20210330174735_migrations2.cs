using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class migrations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumns: new[] { "PrintId", "StoreId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "Orderline",
                keyColumns: new[] { "OrderNumId", "PrintId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Orderline",
                keyColumns: new[] { "OrderNumId", "PrintId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Orderline",
                keyColumns: new[] { "OrderNumId", "PrintId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "Orderline",
                keyColumns: new[] { "OrderNumId", "PrintId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Orderline",
                keyColumns: new[] { "OrderNumId", "PrintId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "Orderline",
                keyColumns: new[] { "OrderNumId", "PrintId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "Orderline",
                keyColumns: new[] { "OrderNumId", "PrintId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrdersId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrdersId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrdersId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrdersId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prints",
                keyColumn: "PrintID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prints",
                keyColumn: "PrintID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prints",
                keyColumn: "PrintID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prints",
                keyColumn: "PrintID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prints",
                keyColumn: "PrintID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Prints",
                keyColumn: "PrintID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Prints",
                keyColumn: "PrintID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Prints",
                keyColumn: "PrintID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreID",
                keyValue: 3);

            migrationBuilder.AlterColumn<byte[]>(
                name: "CustomerPasswordHash",
                table: "Customers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "CustomerPasswordHash",
                table: "Customers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerCity", "CustomerEmail", "CustomerFName", "CustomerLName", "CustomerPasswordHash", "CustomerPasswordSalt", "CustomerPhone", "CustomerState", "CustomerStreet", "CustomerZip" },
                values: new object[,]
                {
                    { 1, "Romeo", "wshakespeare", "William", "Shakespeare", new byte[] { 0, 33, 96, 31, 161, 7 }, null, "555-123-4567", "ND", "295 Juliet Street", 0 },
                    { 2, "Boise", "ljames", "Jane", "Collins", new byte[] { 0, 32, 96, 31, 161, 7 }, null, "555-457-3255", "ID", "938 Jungle Circle", 83705 }
                });

            migrationBuilder.InsertData(
                table: "Prints",
                columns: new[] { "PrintID", "ArtistFName", "ArtistLName", "PrintDecription", "PrintImage", "PrintPrice", "PrintTitle" },
                values: new object[,]
                {
                    { 1, "McGill Library", null, "A print of fantail birds. Look at them, how quaint.", "img/mcgill-library-fantailwrens.jpg", 13.99, "Fantail Wrens" },
                    { 2, "McGill Library", null, "A print of red fox. Look at him go.", "img/mcgill-library-redfox.jpg", 13.99, "Red Fox" },
                    { 3, "McGill Library", null, "A print of a brown hawk owl in a forest. I wonder what he sees.", "img/mcgill-library-brownhawkowl.jpg", 13.99, "Brown Hawk Owl" },
                    { 4, "Tamara", "Menzi", "A print of a place somewhere on a mountain side. Is that tree possibly the home of Tarzan?", "img/tamara-menzi-tarzan.jpg", 17.989999999999998, "Tarzan's Home" },
                    { 5, "Maris", null, "A print of girl picking flowers. How nice.", "img/maris-agirlwithflowers.jpg", 29.989999999999998, "A Girl With Flowers" },
                    { 6, "Jan", "Rombauer", "A print of man who appears to be very pleased with his drink...Cheers?", "img/janrombauer-cheers.jpg", 23.989999999999998, "Cheers" },
                    { 7, "Yuri_B", null, "A painting of knight overlooking the mountains at night.", "img/yuri-b-knightatnight.jpg", 29.989999999999998, "Knight Night" },
                    { 8, "Eberhard", "Grossgasteiger", "A painting of fantial birds. Look at them, how quaint.", "img/eberhard-grossgasteiger-moonpink.jpg", 13.99, "White Clouds in Pink and Blue Clouds" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreID", "StoreCity", "StoreName", "StoreState", "StoreStreet", "StoreZip" },
                values: new object[,]
                {
                    { 1, "Durham", "Prints for Days", "NC", "123 Main Street", 27704 },
                    { 2, "Lincoln", "Pieces of History", "Nebraska", "1863 Gettysburg Street", 68001 },
                    { 3, "Colorado Springs", "Fantasy and Daydreams", "CO", "2336 Sage Lane", 80951 }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "PrintId", "StoreId", "PrintQty" },
                values: new object[,]
                {
                    { 1, 1, 200 },
                    { 8, 3, 49 },
                    { 7, 3, 7 },
                    { 5, 3, 56 },
                    { 4, 3, 24 },
                    { 6, 2, 46 },
                    { 5, 2, 18 },
                    { 3, 2, 125 },
                    { 4, 2, 12 },
                    { 1, 2, 34 },
                    { 6, 1, 16 },
                    { 5, 1, 45 },
                    { 3, 1, 100 },
                    { 2, 1, 150 },
                    { 2, 2, 122 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrdersId", "CustomerId", "OrderDate", "OrderDeliveryDate", "OrderSubtotal", "OrderTax", "OrderTotalPrice", "StoreId" },
                values: new object[,]
                {
                    { 3, 2, new DateTime(2021, 3, 26, 11, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), 61.969999999999999, 4.3399999999999999, 66.310000000000002, 3 },
                    { 1, 1, new DateTime(2021, 3, 1, 7, 25, 36, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), 41.969999999999999, 2.9399999999999999, 44.909999999999997, 1 },
                    { 2, 2, new DateTime(2021, 3, 15, 19, 10, 2, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), 23.989999999999998, 1.6799999999999999, 25.670000000000002, 2 },
                    { 4, 1, new DateTime(2021, 3, 29, 9, 52, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 31, 11, 0, 0, 0, DateTimeKind.Unspecified), 13.99, 0.97999999999999998, 14.970000000000001, 3 }
                });

            migrationBuilder.InsertData(
                table: "Orderline",
                columns: new[] { "OrderNumId", "PrintId", "PrintQty" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 1, 2, 1 },
                    { 2, 6, 1 },
                    { 3, 4, 1 },
                    { 3, 7, 1 },
                    { 3, 8, 1 },
                    { 4, 8, 1 }
                });
        }
    }
}
