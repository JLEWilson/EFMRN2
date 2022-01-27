using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMRN2.Migrations
{
    public partial class Lava : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 264,
                column: "Aux",
                value: "spawn");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 265,
                column: "Aux",
                value: "spawn");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 266,
                column: "Aux",
                value: "spawn");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 284,
                column: "Aux",
                value: "spawn");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 285,
                column: "Aux",
                value: "spawn");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 286,
                column: "Aux",
                value: "spawn");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 337,
                columns: new[] { "Method", "Texture" },
                values: new object[] { 7, "lava" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 264,
                column: "Aux",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 265,
                column: "Aux",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 266,
                column: "Aux",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 284,
                column: "Aux",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 285,
                column: "Aux",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 286,
                column: "Aux",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 337,
                columns: new[] { "Method", "Texture" },
                values: new object[] { 0, "floor" });
        }
    }
}
