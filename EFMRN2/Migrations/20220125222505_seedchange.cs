using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMRN2.Migrations
{
    public partial class seedchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Map",
                columns: new[] { "TileId", "Aux", "Method", "Texture", "Transparent", "X", "Y", "Z" },
                values: new object[,]
                {
                    { 145, "0", 0, "floor", true, 2, 0, 0 },
                    { 146, "0", 0, "floor", true, 2, 1, 0 },
                    { 147, "0", 0, "floor", true, 2, 2, 0 },
                    { 148, "0", 0, "floor", true, 2, 3, 0 },
                    { 149, "0", 0, "floor", true, 2, 4, 0 },
                    { 150, "0", 0, "floor", true, 2, 5, 0 },
                    { 151, "0", 0, "floor", true, 2, 6, 0 },
                    { 152, "0", 0, "floor", true, 2, 7, 0 },
                    { 153, "0", 0, "floor", true, 2, 8, 0 },
                    { 154, "0", 0, "wall", false, 2, 9, 0 },
                    { 155, "0", 0, "wall", false, 2, 10, 0 },
                    { 156, "0", 0, "wall", false, 2, 11, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 156);
        }
    }
}
