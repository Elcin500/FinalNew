using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalNew.Migrations
{
    public partial class createdDateChage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Homes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "dateadd(HOUR,4,getutcdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 30, 20, 13, 0, 879, DateTimeKind.Local).AddTicks(9574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Agents",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "dateadd(HOUR,4,getutcdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 30, 20, 13, 0, 899, DateTimeKind.Local).AddTicks(6016));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Homes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 30, 20, 13, 0, 879, DateTimeKind.Local).AddTicks(9574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "dateadd(HOUR,4,getutcdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Agents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 30, 20, 13, 0, 899, DateTimeKind.Local).AddTicks(6016),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "dateadd(HOUR,4,getutcdate())");
        }
    }
}
