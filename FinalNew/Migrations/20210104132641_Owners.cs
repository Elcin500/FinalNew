using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalNew.Migrations
{
    public partial class Owners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Homes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Agents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Homes_OwnerId",
                table: "Homes",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_OwnerId",
                table: "Agents",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_OwnerId",
                table: "Agents",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_AspNetUsers_OwnerId",
                table: "Homes",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_OwnerId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_AspNetUsers_OwnerId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_OwnerId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Agents_OwnerId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Agents");
        }
    }
}
