using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceForPeripherials.Migrations
{
    public partial class addedLinksForPlayersGear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeadsetLink",
                table: "PlayersGear",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyBoardLink",
                table: "PlayersGear",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MouseLink",
                table: "PlayersGear",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadsetLink",
                table: "PlayersGear");

            migrationBuilder.DropColumn(
                name: "KeyBoardLink",
                table: "PlayersGear");

            migrationBuilder.DropColumn(
                name: "MouseLink",
                table: "PlayersGear");
        }
    }
}
