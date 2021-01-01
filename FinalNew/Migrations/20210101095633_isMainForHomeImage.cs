using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalHomeSale.Migrations
{
    public partial class isMainForHomeImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "HomeImages",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "HomeImages");
        }
    }
}
