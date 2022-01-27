using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMRN2.Migrations
{
    public partial class Ice2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 137,
                column: "Method",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 157,
                column: "Method",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 177,
                column: "Method",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 197,
                column: "Method",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 217,
                column: "Method",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 237,
                column: "Method",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 257,
                column: "Method",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 277,
                column: "Method",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 137,
                column: "Method",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 157,
                column: "Method",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 177,
                column: "Method",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 197,
                column: "Method",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 217,
                column: "Method",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 237,
                column: "Method",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 257,
                column: "Method",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 277,
                column: "Method",
                value: 0);
        }
    }
}
