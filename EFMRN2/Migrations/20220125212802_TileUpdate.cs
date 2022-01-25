using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMRN2.Migrations
{
    public partial class TileUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Item_ItemId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Players_ItemId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "Aux",
                table: "Map",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 1,
                columns: new[] { "Aux", "Texture", "Transparent" },
                values: new object[] { "0", "wall", false });

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 2,
                columns: new[] { "Aux", "Texture", "Y" },
                values: new object[] { "0", "wall", 1 });

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 3,
                columns: new[] { "Aux", "Texture", "Y" },
                values: new object[] { "0", "wall", 2 });

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 4,
                columns: new[] { "Aux", "Texture", "Transparent", "Y" },
                values: new object[] { "0", "wall", false, 3 });

            migrationBuilder.InsertData(
                table: "Map",
                columns: new[] { "TileId", "Aux", "Method", "Texture", "Transparent", "X", "Y", "Z" },
                values: new object[,]
                {
                    { 132, "0", 0, "wall", false, 11, 11, 0 },
                    { 129, "0", 0, "floor", true, 11, 8, 0 },
                    { 117, "0", 0, "wall", false, 10, 8, 0 },
                    { 105, "0", 0, "floor", true, 9, 8, 0 },
                    { 93, "0", 0, "floor", true, 8, 8, 0 },
                    { 81, "0", 0, "floor", true, 7, 8, 0 },
                    { 69, "0", 0, "floor", true, 6, 8, 0 },
                    { 57, "0", 0, "floor", true, 5, 8, 0 },
                    { 45, "0", 0, "floor", true, 4, 8, 0 },
                    { 33, "0", 0, "wall", false, 3, 8, 0 },
                    { 21, "0", 0, "wall", false, 1, 8, 0 },
                    { 9, "0", 0, "wall", false, 0, 8, 0 },
                    { 140, "0", 0, "wall", false, 12, 7, 0 },
                    { 128, "0", 0, "floor", true, 11, 7, 0 },
                    { 116, "0", 0, "wall", false, 10, 7, 0 },
                    { 141, "0", 0, "wall", false, 12, 8, 0 },
                    { 104, "0", 0, "floor", true, 9, 7, 0 },
                    { 80, "0", 0, "floor", true, 7, 7, 0 },
                    { 68, "0", 0, "floor", true, 6, 7, 0 },
                    { 56, "0", 0, "floor", true, 5, 7, 0 },
                    { 44, "0", 0, "floor", true, 4, 7, 0 },
                    { 32, "0", 0, "wall", false, 3, 7, 0 },
                    { 20, "0", 0, "wall", false, 1, 7, 0 },
                    { 8, "0", 0, "wall", false, 0, 7, 0 },
                    { 139, "0", 0, "wall", false, 12, 6, 0 },
                    { 127, "0", 0, "floor", true, 11, 6, 0 },
                    { 115, "0", 0, "wall", false, 10, 6, 0 },
                    { 103, "0", 0, "floor", true, 9, 6, 0 },
                    { 91, "0", 0, "floor", true, 8, 6, 0 },
                    { 79, "0", 0, "floor", true, 7, 6, 0 },
                    { 67, "0", 0, "floor", true, 6, 6, 0 },
                    { 92, "0", 0, "floor", true, 8, 7, 0 },
                    { 10, "0", 0, "wall", false, 0, 9, 0 },
                    { 22, "0", 0, "wall", false, 1, 9, 0 },
                    { 34, "0", 0, "wall", false, 3, 9, 0 },
                    { 120, "0", 0, "wall", false, 10, 11, 0 },
                    { 108, "0", 0, "wall", false, 9, 11, 0 },
                    { 96, "0", 0, "wall", false, 8, 11, 0 },
                    { 84, "0", 0, "wall", false, 7, 11, 0 },
                    { 72, "0", 0, "wall", false, 6, 11, 0 },
                    { 60, "0", 0, "wall", false, 5, 11, 0 },
                    { 48, "0", 0, "wall", false, 4, 11, 0 },
                    { 36, "0", 0, "wall", false, 3, 11, 0 },
                    { 24, "0", 0, "wall", false, 1, 11, 0 },
                    { 12, "0", 0, "wall", false, 0, 11, 0 },
                    { 143, "0", 0, "wall", false, 12, 10, 0 },
                    { 131, "0", 0, "wall", false, 11, 10, 0 },
                    { 119, "0", 0, "wall", false, 10, 10, 0 },
                    { 107, "0", 0, "wall", false, 9, 10, 0 },
                    { 95, "0", 0, "wall", false, 8, 10, 0 },
                    { 83, "0", 0, "wall", false, 7, 10, 0 },
                    { 71, "0", 0, "wall", false, 6, 10, 0 },
                    { 55, "0", 0, "floor", true, 5, 6, 0 },
                    { 58, "0", 0, "wall", false, 5, 9, 0 },
                    { 70, "0", 0, "wall", false, 6, 9, 0 },
                    { 82, "0", 0, "wall", false, 7, 9, 0 },
                    { 94, "0", 0, "wall", false, 8, 9, 0 },
                    { 106, "0", 0, "wall", false, 9, 9, 0 },
                    { 144, "0", 0, "wall", false, 12, 11, 0 },
                    { 118, "0", 0, "wall", false, 10, 9, 0 },
                    { 142, "0", 0, "wall", false, 12, 9, 0 },
                    { 11, "0", 0, "wall", false, 0, 10, 0 },
                    { 23, "0", 0, "wall", false, 1, 10, 0 },
                    { 35, "0", 0, "wall", false, 3, 10, 0 },
                    { 47, "0", 0, "wall", false, 4, 10, 0 },
                    { 59, "0", 0, "wall", false, 5, 10, 0 },
                    { 130, "0", 0, "wall", false, 11, 9, 0 },
                    { 46, "0", 0, "wall", false, 4, 9, 0 },
                    { 43, "0", 0, "floor", true, 4, 6, 0 },
                    { 19, "0", 0, "wall", false, 1, 6, 0 },
                    { 110, "0", 0, "wall", false, 10, 1, 0 },
                    { 122, "0", 0, "wall", false, 11, 1, 0 },
                    { 134, "0", 0, "wall", false, 12, 1, 0 },
                    { 15, "0", 0, "wall", false, 1, 2, 0 },
                    { 27, "0", 0, "wall", false, 3, 2, 0 },
                    { 39, "0", 0, "wall", false, 4, 2, 0 },
                    { 98, "0", 0, "wall", false, 9, 1, 0 },
                    { 51, "0", 0, "wall", false, 5, 2, 0 },
                    { 75, "0", 0, "wall", false, 7, 2, 0 },
                    { 87, "0", 0, "wall", false, 8, 2, 0 },
                    { 99, "0", 0, "wall", false, 9, 2, 0 },
                    { 111, "0", 0, "wall", false, 10, 2, 0 },
                    { 123, "0", 0, "wall", false, 11, 2, 0 },
                    { 135, "0", 0, "wall", false, 12, 2, 0 },
                    { 63, "0", 0, "wall", false, 6, 2, 0 },
                    { 16, "0", 0, "wall", false, 1, 3, 0 },
                    { 86, "0", 0, "wall", false, 8, 1, 0 },
                    { 62, "0", 0, "wall", false, 6, 1, 0 },
                    { 25, "0", 0, "wall", false, 3, 0, 0 },
                    { 37, "0", 0, "wall", false, 4, 0, 0 },
                    { 49, "0", 0, "wall", false, 5, 0, 0 },
                    { 61, "0", 0, "wall", false, 6, 0, 0 },
                    { 73, "0", 0, "wall", false, 7, 0, 0 },
                    { 85, "0", 0, "wall", false, 8, 0, 0 },
                    { 74, "0", 0, "wall", false, 7, 1, 0 },
                    { 97, "0", 0, "wall", false, 9, 0, 0 },
                    { 121, "0", 0, "wall", false, 11, 0, 0 },
                    { 133, "0", 0, "wall", false, 12, 0, 0 },
                    { 14, "0", 0, "wall", false, 1, 1, 0 },
                    { 26, "0", 0, "wall", false, 3, 1, 0 },
                    { 38, "0", 0, "wall", false, 4, 1, 0 },
                    { 50, "0", 0, "wall", false, 5, 1, 0 },
                    { 109, "0", 0, "wall", false, 10, 0, 0 },
                    { 31, "0", 0, "wall", false, 3, 6, 0 },
                    { 28, "0", 0, "wall", false, 3, 3, 0 },
                    { 52, "0", 0, "floor", true, 5, 3, 0 },
                    { 137, "0", 0, "wall", false, 12, 4, 0 },
                    { 6, "0", 0, "wall", false, 0, 5, 0 },
                    { 18, "0", 0, "wall", false, 1, 5, 0 },
                    { 30, "0", 0, "wall", false, 3, 5, 0 },
                    { 42, "0", 0, "floor", true, 4, 5, 0 },
                    { 54, "0", 0, "void", false, 5, 5, 0 },
                    { 125, "0", 0, "floor", true, 11, 4, 0 },
                    { 66, "0", 0, "floor", true, 6, 5, 0 },
                    { 90, "0", 0, "floor", true, 8, 5, 0 },
                    { 102, "0", 0, "floor", true, 9, 5, 0 },
                    { 114, "0", 0, "wall", false, 10, 5, 0 },
                    { 126, "0", 0, "floor", true, 11, 5, 0 },
                    { 138, "0", 0, "wall", false, 12, 5, 0 },
                    { 7, "0", 0, "wall", false, 0, 6, 0 },
                    { 78, "0", 0, "floor", true, 7, 5, 0 },
                    { 40, "0", 0, "floor", true, 4, 3, 0 },
                    { 113, "0", 0, "wall", false, 10, 4, 0 },
                    { 89, "0", 0, "floor", true, 8, 4, 0 },
                    { 64, "0", 0, "floor", true, 6, 3, 0 },
                    { 76, "0", 0, "floor", true, 7, 3, 0 },
                    { 88, "0", 0, "floor", true, 8, 3, 0 },
                    { 100, "0", 0, "floor", true, 9, 3, 0 },
                    { 112, "0", 0, "wall", false, 10, 3, 0 },
                    { 124, "0", 0, "floor", true, 11, 3, 0 },
                    { 101, "0", 0, "floor", true, 9, 4, 0 },
                    { 136, "0", 0, "wall", false, 12, 3, 0 },
                    { 17, "0", 0, "wall", false, 1, 4, 0 },
                    { 29, "0", 0, "wall", false, 3, 4, 0 },
                    { 41, "0", 0, "floor", true, 4, 4, 0 },
                    { 53, "0", 0, "floor", true, 5, 4, 0 },
                    { 65, "0", 0, "floor", true, 6, 4, 0 },
                    { 77, "0", 0, "floor", true, 7, 4, 0 },
                    { 5, "0", 0, "wall", false, 0, 4, 0 },
                    { 13, "0", 0, "wall", false, 1, 0, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 144);

            migrationBuilder.DropColumn(
                name: "Aux",
                table: "Map");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                });

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 1,
                columns: new[] { "Texture", "Transparent" },
                values: new object[] { "pain", true });

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 2,
                columns: new[] { "Texture", "Y" },
                values: new object[] { "despare", 0 });

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 3,
                columns: new[] { "Texture", "Y" },
                values: new object[] { "Time", 0 });

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 4,
                columns: new[] { "Texture", "Transparent", "Y" },
                values: new object[] { "sour", true, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Players_ItemId",
                table: "Players",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Item_ItemId",
                table: "Players",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
