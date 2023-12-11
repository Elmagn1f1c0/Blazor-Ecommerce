using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { 1, new DateTime(2023, 12, 11, 21, 5, 20, 77, DateTimeKind.Local).AddTicks(2014), "chibueze@gmail.com", new byte[] { 1, 0, 0, 0, 1, 0, 0, 39, 16, 0, 0, 0, 16, 169, 123, 251, 58, 59, 192, 172, 238, 25, 102, 133, 166, 209, 76, 34, 10, 102, 2, 125, 175, 96, 181, 66, 90, 203, 227, 72, 34, 0, 174, 67, 244, 62, 245, 204, 210, 115, 157, 143, 250, 121, 13, 25, 143, 244, 17, 200, 68 }, new byte[] { 100, 26, 233, 218, 22, 24, 191, 120, 95, 212, 201, 69, 180, 4, 158, 86 }, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
