using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class migrations3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 2, 1, 150 },
                    { 3, 1, 100 },
                    { 5, 1, 45 },
                    { 6, 1, 16 },
                    { 1, 2, 34 },
                    { 2, 2, 122 },
                    { 3, 2, 125 },
                    { 4, 2, 12 },
                    { 5, 2, 18 },
                    { 6, 2, 46 },
                    { 4, 3, 24 },
                    { 5, 3, 56 },
                    { 7, 3, 7 },
                    { 8, 3, 49 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
