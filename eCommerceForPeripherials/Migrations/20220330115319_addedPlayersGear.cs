using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceForPeripherials.Migrations
{
    public partial class addedPlayersGear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayersGear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MouseHz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DPI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sens = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eDPI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZoomSens = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WinSens = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RawInput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monitor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonitorHz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AspectRatio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScalingMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MousePad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyBoard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Headset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CFG = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersGear", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersGear");
        }
    }
}
