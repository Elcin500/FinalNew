using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalNew.Migrations
{
    public partial class newdistricts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Districts_DistrictId",
                table: "Homes");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "Homes",
                newName: "NMRDistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Homes_DistrictId",
                table: "Homes",
                newName: "IX_Homes_NMRDistrictId");

            migrationBuilder.AddColumn<int>(
                name: "BakuDistrictId",
                table: "Homes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BakuDistricts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakuDistricts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BakuDistricts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NMRDistricts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NMRDistricts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NMRDistricts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homes_BakuDistrictId",
                table: "Homes",
                column: "BakuDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_BakuDistricts_CityId",
                table: "BakuDistricts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_NMRDistricts_CityId",
                table: "NMRDistricts",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_BakuDistricts_BakuDistrictId",
                table: "Homes",
                column: "BakuDistrictId",
                principalTable: "BakuDistricts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_NMRDistricts_NMRDistrictId",
                table: "Homes",
                column: "NMRDistrictId",
                principalTable: "NMRDistricts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_BakuDistricts_BakuDistrictId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_NMRDistricts_NMRDistrictId",
                table: "Homes");

            migrationBuilder.DropTable(
                name: "BakuDistricts");

            migrationBuilder.DropTable(
                name: "NMRDistricts");

            migrationBuilder.DropIndex(
                name: "IX_Homes_BakuDistrictId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "BakuDistrictId",
                table: "Homes");

            migrationBuilder.RenameColumn(
                name: "NMRDistrictId",
                table: "Homes",
                newName: "DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Homes_NMRDistrictId",
                table: "Homes",
                newName: "IX_Homes_DistrictId");

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Districts_DistrictId",
                table: "Homes",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
