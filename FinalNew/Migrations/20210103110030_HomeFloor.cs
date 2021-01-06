using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalNew.Migrations
{
    public partial class HomeFloor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Homes",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Homes");
        }
    }
}
