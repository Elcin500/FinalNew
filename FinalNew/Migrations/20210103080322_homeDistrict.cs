using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalNew.Migrations
{
    public partial class homeDistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Homes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Homes_DistrictId",
                table: "Homes",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Districts_DistrictId",
                table: "Homes",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Districts_DistrictId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_DistrictId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Homes");
        }
    }
}
