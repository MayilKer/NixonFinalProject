using Microsoft.EntityFrameworkCore.Migrations;

namespace NixonE.Migrations
{
    public partial class CategoryTableUpdate_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MainCategory",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainCategory",
                table: "Categories");
        }
    }
}
