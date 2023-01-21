using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Entities.Migrations
{
    public partial class Intitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "TBL_User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    HousekeeperId = table.Column<int>(type: "int", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_User_TBL_User_CreateUserId",
                        column: x => x.CreateUserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_User_TBL_User_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_About",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceBook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisionImage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_About", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_About_TBL_User_CreateUserId",
                        column: x => x.CreateUserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_About_TBL_User_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ContactUs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ContactUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ContactUs_TBL_User_CreateUserId",
                        column: x => x.CreateUserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_ContactUs_TBL_User_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Faqs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Faqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Faqs_TBL_User_CreateUserId",
                        column: x => x.CreateUserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_Faqs_TBL_User_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_FaqsDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaqsId = table.Column<int>(type: "int", nullable: false),
                    QuestionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_FaqsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_FaqsDetails_TBL_Faqs_FaqsId",
                        column: x => x.FaqsId,
                        principalSchema: "dbo",
                        principalTable: "TBL_Faqs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_FaqsDetails_TBL_User_CreateUserId",
                        column: x => x.CreateUserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_FaqsDetails_TBL_User_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TBL_User",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "Email", "EmployeeId", "HousekeeperId", "IsBlock", "ModifyDate", "ModifyUserId", "NameAr", "NameEn", "Password", "Phone", "UserName", "UserType" },
                values: new object[] { 1, new DateTime(2021, 11, 17, 13, 51, 29, 239, DateTimeKind.Local).AddTicks(9212), 1, null, null, null, false, null, null, "مدير النظام", "System admin", "11KThNU1zRI=", null, "admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_About_CreateUserId",
                schema: "dbo",
                table: "TBL_About",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_About_ModifyUserId",
                schema: "dbo",
                table: "TBL_About",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ContactUs_CreateUserId",
                schema: "dbo",
                table: "TBL_ContactUs",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ContactUs_ModifyUserId",
                schema: "dbo",
                table: "TBL_ContactUs",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Faqs_CreateUserId",
                schema: "dbo",
                table: "TBL_Faqs",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Faqs_ModifyUserId",
                schema: "dbo",
                table: "TBL_Faqs",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_FaqsDetails_CreateUserId",
                schema: "dbo",
                table: "TBL_FaqsDetails",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_FaqsDetails_FaqsId",
                schema: "dbo",
                table: "TBL_FaqsDetails",
                column: "FaqsId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_FaqsDetails_ModifyUserId",
                schema: "dbo",
                table: "TBL_FaqsDetails",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_User_CreateUserId",
                schema: "dbo",
                table: "TBL_User",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_User_ModifyUserId",
                schema: "dbo",
                table: "TBL_User",
                column: "ModifyUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_About",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_ContactUs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_FaqsDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_Faqs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_User",
                schema: "dbo");
        }
    }
}
