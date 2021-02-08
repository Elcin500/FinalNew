using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalNew.Migrations
{
    public partial class appInfoCategoryImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryPhoto1",
                table: "AppInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryPhoto2",
                table: "AppInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryPhoto3",
                table: "AppInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryPhoto4",
                table: "AppInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryPhoto1",
                table: "AppInfos");

            migrationBuilder.DropColumn(
                name: "CategoryPhoto2",
                table: "AppInfos");

            migrationBuilder.DropColumn(
                name: "CategoryPhoto3",
                table: "AppInfos");

            migrationBuilder.DropColumn(
                name: "CategoryPhoto4",
                table: "AppInfos");
        }
    }
}
