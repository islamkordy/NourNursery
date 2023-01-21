using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Entities.Migrations
{
    public partial class UpdateAboutTbl2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectTitleAr",
                schema: "dbo",
                table: "TBL_About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectTitleEn",
                schema: "dbo",
                table: "TBL_About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TBL_User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 11, 22, 16, 12, 53, 562, DateTimeKind.Local).AddTicks(9578));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectTitleAr",
                schema: "dbo",
                table: "TBL_About");

            migrationBuilder.DropColumn(
                name: "ProjectTitleEn",
                schema: "dbo",
                table: "TBL_About");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TBL_User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 11, 22, 15, 50, 35, 149, DateTimeKind.Local).AddTicks(6854));
        }
    }
}
