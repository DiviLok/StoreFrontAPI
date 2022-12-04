using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreFrontAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "availableSizes",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_availableSizes", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "clothes",
                columns: table => new
                {
                    ClothId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clothes", x => x.ClothId);
                });

            migrationBuilder.CreateTable(
                name: "kidsclothes",
                columns: table => new
                {
                    KidClothID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KidClothName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KidClothType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kidsclothes", x => x.KidClothID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "availableSizes");

            migrationBuilder.DropTable(
                name: "clothes");

            migrationBuilder.DropTable(
                name: "kidsclothes");
        }
    }
}
