using Microsoft.EntityFrameworkCore.Migrations;

namespace NixonE.Migrations
{
    public partial class updateordersss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColourId",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ColourId",
                table: "OrderItems",
                column: "ColourId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Colors_ColourId",
                table: "OrderItems",
                column: "ColourId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Colors_ColourId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ColourId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ColourId",
                table: "OrderItems");
        }
    }
}
