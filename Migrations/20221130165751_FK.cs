using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreFrontAPI.Migrations
{
    /// <inheritdoc />
    public partial class FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KidClothID",
                table: "clothes");

            migrationBuilder.AddColumn<int>(
                name: "ClothId",
                table: "kidsclothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "clothesClothId",
                table: "kidsclothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_kidsclothes_clothesClothId",
                table: "kidsclothes",
                column: "clothesClothId");

            migrationBuilder.AddForeignKey(
                name: "FK_kidsclothes_clothes_clothesClothId",
                table: "kidsclothes",
                column: "clothesClothId",
                principalTable: "clothes",
                principalColumn: "ClothId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kidsclothes_clothes_clothesClothId",
                table: "kidsclothes");

            migrationBuilder.DropIndex(
                name: "IX_kidsclothes_clothesClothId",
                table: "kidsclothes");

            migrationBuilder.DropColumn(
                name: "ClothId",
                table: "kidsclothes");

            migrationBuilder.DropColumn(
                name: "clothesClothId",
                table: "kidsclothes");

            migrationBuilder.AddColumn<int>(
                name: "KidClothID",
                table: "clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
