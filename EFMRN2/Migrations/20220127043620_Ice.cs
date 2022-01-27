using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMRN2.Migrations
{
    public partial class Ice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 137,
                column: "Texture",
                value: "ice");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 157,
                column: "Texture",
                value: "ice");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 177,
                column: "Texture",
                value: "ice");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 197,
                column: "Texture",
                value: "ice");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 217,
                column: "Texture",
                value: "ice");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 237,
                column: "Texture",
                value: "ice");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 257,
                column: "Texture",
                value: "ice");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 277,
                column: "Texture",
                value: "ice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 137,
                column: "Texture",
                value: "floor");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 157,
                column: "Texture",
                value: "floor");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 177,
                column: "Texture",
                value: "floor");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 197,
                column: "Texture",
                value: "floor");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 217,
                column: "Texture",
                value: "floor");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 237,
                column: "Texture",
                value: "floor");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 257,
                column: "Texture",
                value: "floor");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 277,
                column: "Texture",
                value: "floor");
        }
    }
}
