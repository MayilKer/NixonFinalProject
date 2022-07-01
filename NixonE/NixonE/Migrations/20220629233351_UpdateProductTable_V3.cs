using Microsoft.EntityFrameworkCore.Migrations;

namespace NixonE.Migrations
{
    public partial class UpdateProductTable_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Products");
        }
    }
}
