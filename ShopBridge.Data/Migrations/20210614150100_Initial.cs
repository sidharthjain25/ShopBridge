using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ProductCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "ContactNumber", "Email", "FullName", "Password", "UserName" },
                values: new object[] { 1L, "95089532233", "Shakespeare", "Sidharth Jain", "xyx123", "sidharthjain" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "ContactNumber", "Email", "FullName", "Password", "UserName" },
                values: new object[] { 2L, "95089532233", "Shakespeare", "Test User", "xyx123", "UserNamw" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
