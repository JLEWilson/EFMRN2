using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMRN2.Migrations
{
    public partial class SeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_test",
                table: "test");

            migrationBuilder.RenameTable(
                name: "test",
                newName: "Map");

            migrationBuilder.RenameColumn(
                name: "transparent",
                table: "Map",
                newName: "Transparent");

            migrationBuilder.RenameColumn(
                name: "texture",
                table: "Map",
                newName: "Texture");

            migrationBuilder.AddColumn<int>(
                name: "Method",
                table: "Map",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Map",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y",
                table: "Map",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Z",
                table: "Map",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Map",
                table: "Map",
                column: "TileId");

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

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Z = table.Column<int>(type: "int", nullable: false),
                    Bearing = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Transparency = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Map",
                columns: new[] { "TileId", "Method", "Texture", "Transparent", "X", "Y", "Z" },
                values: new object[,]
                {
                    { 1, 0, "pain", true, 0, 0, 0 },
                    { 2, 0, "despare", false, 0, 0, 0 },
                    { 3, 0, "Time", false, 0, 0, 0 },
                    { 4, 0, "sour", true, 0, 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_ItemId",
                table: "Players",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Map",
                table: "Map");

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "TileId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Method",
                table: "Map");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Map");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Map");

            migrationBuilder.DropColumn(
                name: "Z",
                table: "Map");

            migrationBuilder.RenameTable(
                name: "Map",
                newName: "test");

            migrationBuilder.RenameColumn(
                name: "Transparent",
                table: "test",
                newName: "transparent");

            migrationBuilder.RenameColumn(
                name: "Texture",
                table: "test",
                newName: "texture");

            migrationBuilder.AddPrimaryKey(
                name: "PK_test",
                table: "test",
                column: "TileId");
        }
    }
}
