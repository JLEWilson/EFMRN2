using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMRN2.Migrations
{
    public partial class PressureTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 150,
                columns: new[] { "Aux", "Texture" },
                values: new object[] { "110", "pressure" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 150,
                columns: new[] { "Aux", "Texture" },
                values: new object[] { "0", "floor" });
        }
    }
}
