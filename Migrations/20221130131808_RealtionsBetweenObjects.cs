using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreFrontAPI.Migrations
{
    /// <inheritdoc />
    public partial class RealtionsBetweenObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KidClothID",
                table: "clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "clothesAndSizes",
                columns: table => new
                {
                    ClothId = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clothesAndSizes", x => new { x.SizeID, x.ClothId });
                    table.ForeignKey(
                        name: "FK_clothesAndSizes_availableSizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "availableSizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clothesAndSizes_clothes_ClothId",
                        column: x => x.ClothId,
                        principalTable: "clothes",
                        principalColumn: "ClothId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clothesAndSizes_ClothId",
                table: "clothesAndSizes",
                column: "ClothId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clothesAndSizes");

            migrationBuilder.DropColumn(
                name: "KidClothID",
                table: "clothes");
        }
    }
}
