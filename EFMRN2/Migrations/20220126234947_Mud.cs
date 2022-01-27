using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMRN2.Migrations
{
    public partial class Mud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 152,
                columns: new[] { "Aux", "Texture" },
                values: new object[] { "mud", "mud" });

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 172,
                columns: new[] { "Aux", "Texture" },
                values: new object[] { "mud", "mud" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 152,
                columns: new[] { "Aux", "Texture" },
                values: new object[] { "0", "floor" });

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 172,
                columns: new[] { "Aux", "Texture" },
                values: new object[] { "0", "floor" });
        }
    }
}
