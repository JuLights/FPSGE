using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceForPeripherials.Migrations
{
    public partial class addedItemCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemCondition",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCondition",
                table: "Items");
        }
    }
}
