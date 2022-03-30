using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceForPeripherials.Migrations
{
    public partial class addedPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maps = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<int>(type: "int", nullable: false),
                    KD_Diff = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
