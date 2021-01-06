using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalNew.Migrations
{
    public partial class ReachToAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Agency",
                table: "Homes");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Homes",
                newName: "SellerName");

            migrationBuilder.RenameColumn(
                name: "Room",
                table: "Homes",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Homes",
                newName: "Map");

            migrationBuilder.RenameColumn(
                name: "Garage",
                table: "Homes",
                newName: "LandArea");

            migrationBuilder.RenameColumn(
                name: "Bath",
                table: "Homes",
                newName: "AnnounceType");

            migrationBuilder.RenameColumn(
                name: "Agent",
                table: "Homes",
                newName: "Address");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Homes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Homes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 30, 20, 13, 0, 879, DateTimeKind.Local).AddTicks(9574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 23, 23, 23, 30, 379, DateTimeKind.Local).AddTicks(1586));

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Homes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BathCount",
                table: "Homes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Homes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GarageCount",
                table: "Homes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MetroId",
                table: "Homes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomCount",
                table: "Homes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2020, 12, 30, 20, 13, 0, 899, DateTimeKind.Local).AddTicks(6016))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterLogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOurs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhoto1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhoto2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhoto3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnounceAdvantages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentAdvantages = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homes_AgentId",
                table: "Homes",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_CityId",
                table: "Homes",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_MetroId",
                table: "Homes",
                column: "MetroId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_HomeId",
                table: "Comment",
                column: "HomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Agents_AgentId",
                table: "Homes",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Cities_CityId",
                table: "Homes",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Metros_MetroId",
                table: "Homes",
                column: "MetroId",
                principalTable: "Metros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Agents_AgentId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Cities_CityId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Metros_MetroId",
                table: "Homes");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "AppInfos");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Metros");

            migrationBuilder.DropIndex(
                name: "IX_Homes_AgentId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_CityId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_MetroId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "BathCount",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "GarageCount",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "MetroId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "RoomCount",
                table: "Homes");

            migrationBuilder.RenameColumn(
                name: "SellerName",
                table: "Homes",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Homes",
                newName: "Room");

            migrationBuilder.RenameColumn(
                name: "Map",
                table: "Homes",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "LandArea",
                table: "Homes",
                newName: "Garage");

            migrationBuilder.RenameColumn(
                name: "AnnounceType",
                table: "Homes",
                newName: "Bath");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Homes",
                newName: "Agent");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Homes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 23, 23, 23, 30, 379, DateTimeKind.Local).AddTicks(1586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 30, 20, 13, 0, 879, DateTimeKind.Local).AddTicks(9574));

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Agency",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
