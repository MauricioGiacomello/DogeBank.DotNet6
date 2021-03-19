using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountsUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    accountType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    balanceCredit = table.Column<double>(type: "float", maxLength: 30, nullable: false),
                    accountNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    userMF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    nameMother = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    nameFather = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    userMF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_email",
                table: "User",
                column: "email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsUser");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
