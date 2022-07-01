using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NixonE.Migrations
{
    public partial class AddedStyleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_StyleId",
                table: "Products",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Styles_StyleId",
                table: "Products",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Styles_StyleId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_Products_StyleId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Products");
        }
    }
}
