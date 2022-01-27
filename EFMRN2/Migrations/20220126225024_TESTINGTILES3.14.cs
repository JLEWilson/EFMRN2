using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMRN2.Migrations
{
    public partial class TESTINGTILES314 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 210,
                column: "Method",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 250,
                column: "Method",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 210,
                column: "Method",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 250,
                column: "Method",
                value: 0);
        }
    }
}
