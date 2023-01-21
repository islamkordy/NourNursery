using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Entities.Migrations
{
    public partial class UpdateAboutTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactAr",
                schema: "dbo",
                table: "TBL_About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEn",
                schema: "dbo",
                table: "TBL_About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionAr",
                schema: "dbo",
                table: "TBL_About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionEn",
                schema: "dbo",
                table: "TBL_About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueAr",
                schema: "dbo",
                table: "TBL_About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueEn",
                schema: "dbo",
                table: "TBL_About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisionAr",
                schema: "dbo",
                table: "TBL_About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisionEn",
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
                value: new DateTime(2021, 11, 22, 15, 50, 35, 149, DateTimeKind.Local).AddTicks(6854));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactAr",
                schema: "dbo",
                table: "TBL_About");

            migrationBuilder.DropColumn(
                name: "ContactEn",
                schema: "dbo",
                table: "TBL_About");

            migrationBuilder.DropColumn(
                name: "MissionAr",
                schema: "dbo",
                table: "TBL_About");

            migrationBuilder.DropColumn(
                name: "MissionEn",
                schema: "dbo",
                table: "TBL_About");

            migrationBuilder.DropColumn(
                name: "ValueAr",
                schema: "dbo",
                table: "TBL_About");

            migrationBuilder.DropColumn(
                name: "ValueEn",
                schema: "dbo",
                table: "TBL_About");

            migrationBuilder.DropColumn(
                name: "VisionAr",
                schema: "dbo",
                table: "TBL_About");

            migrationBuilder.DropColumn(
                name: "VisionEn",
                schema: "dbo",
                table: "TBL_About");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TBL_User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 11, 17, 21, 37, 43, 263, DateTimeKind.Local).AddTicks(9692));
        }
    }
}
