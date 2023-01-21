using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Entities.Migrations
{
    public partial class UpdateProductTBL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescAr2",
                schema: "dbo",
                table: "TBL_Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescEn2",
                schema: "dbo",
                table: "TBL_Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMainPage",
                schema: "dbo",
                table: "TBL_Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TBL_User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 11, 22, 17, 12, 9, 454, DateTimeKind.Local).AddTicks(3745));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescAr2",
                schema: "dbo",
                table: "TBL_Product");

            migrationBuilder.DropColumn(
                name: "DescEn2",
                schema: "dbo",
                table: "TBL_Product");

            migrationBuilder.DropColumn(
                name: "IsMainPage",
                schema: "dbo",
                table: "TBL_Product");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TBL_User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 11, 22, 16, 12, 53, 562, DateTimeKind.Local).AddTicks(9578));
        }
    }
}
