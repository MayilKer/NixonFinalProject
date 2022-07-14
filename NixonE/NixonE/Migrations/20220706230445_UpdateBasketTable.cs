using Microsoft.EntityFrameworkCore.Migrations;

namespace NixonE.Migrations
{
    public partial class UpdateBasketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColourId",
                table: "Baskets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ColourId",
                table: "Baskets",
                column: "ColourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Colors_ColourId",
                table: "Baskets",
                column: "ColourId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Colors_ColourId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_ColourId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "ColourId",
                table: "Baskets");
        }
    }
}
