using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyTrees.Migrations
{
    public partial class AddPaintingTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaintingTypes",
                table: "Paintings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaintingTypes",
                table: "Paintings");
        }
    }
}
