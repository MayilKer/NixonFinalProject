using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NixonE.Migrations
{
    public partial class AddedUseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Uses",
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
                    table.PrimaryKey("PK_Uses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UseId",
                table: "Products",
                column: "UseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Uses_UseId",
                table: "Products",
                column: "UseId",
                principalTable: "Uses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Uses_UseId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Uses");

            migrationBuilder.DropIndex(
                name: "IX_Products_UseId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "Products");
        }
    }
}
