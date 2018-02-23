using Microsoft.EntityFrameworkCore.Migrations;

namespace Auctions.Migrations
{
    public partial class Added_Auctions_Patterns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoundId",
                table: "Provider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Auctions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provider_RoundId",
                table: "Provider",
                column: "RoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Round_RoundId",
                table: "Provider",
                column: "RoundId",
                principalTable: "Round",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Round_RoundId",
                table: "Provider");

            migrationBuilder.DropIndex(
                name: "IX_Provider_RoundId",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Auctions");
        }
    }
}
