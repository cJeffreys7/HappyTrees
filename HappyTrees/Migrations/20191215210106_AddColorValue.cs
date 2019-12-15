using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyTrees.Migrations
{
    public partial class AddColorValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorValue",
                table: "Colors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorValue",
                table: "Colors");
        }
    }
}
