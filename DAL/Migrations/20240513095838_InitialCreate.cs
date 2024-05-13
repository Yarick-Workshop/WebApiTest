using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rectangles",
                columns: table => new
                {
                    RectangleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MinX = table.Column<double>(type: "REAL", nullable: false),
                    MinY = table.Column<double>(type: "REAL", nullable: false),
                    MaxX = table.Column<double>(type: "REAL", nullable: false),
                    MaxY = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangles", x => x.RectangleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_MinX_MinY_MaxX_MaxY",
                table: "Rectangles",
                columns: new[] { "MinX", "MinY", "MaxX", "MaxY" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rectangles");
        }
    }
}
