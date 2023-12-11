using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class NewOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { 1, new DateTime(2023, 12, 11, 21, 15, 56, 463, DateTimeKind.Local).AddTicks(1589), "chibueze@gmail.com", new byte[] { 1, 0, 0, 0, 1, 0, 0, 39, 16, 0, 0, 0, 16, 74, 60, 213, 105, 25, 144, 102, 238, 100, 104, 182, 208, 27, 186, 121, 235, 91, 77, 89, 13, 91, 34, 140, 229, 154, 96, 155, 83, 87, 126, 159, 180, 51, 26, 209, 42, 147, 16, 255, 201, 80, 226, 88, 81, 18, 129, 111, 250 }, new byte[] { 203, 244, 58, 65, 54, 119, 17, 233, 54, 19, 154, 202, 79, 104, 20, 75 }, "Admin" });
        }
    }
}
