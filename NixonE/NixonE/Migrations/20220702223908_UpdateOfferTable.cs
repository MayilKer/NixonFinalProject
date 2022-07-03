using Microsoft.EntityFrameworkCore.Migrations;

namespace NixonE.Migrations
{
    public partial class UpdateOfferTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OfferHeroes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "OfferHeroes");
        }
    }
}
