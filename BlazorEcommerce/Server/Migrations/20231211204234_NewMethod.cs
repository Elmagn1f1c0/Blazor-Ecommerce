using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class NewMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { 1, new DateTime(2023, 12, 11, 21, 42, 34, 417, DateTimeKind.Local).AddTicks(1997), "chibueze@gmail.com", new byte[] { 254, 182, 218, 136, 124, 79, 159, 40, 27, 222, 49, 105, 191, 162, 254, 69, 154, 94, 234, 161, 185, 159, 249, 95, 83, 254, 138, 72, 36, 133, 119, 203, 0, 136, 155, 89, 32, 86, 224, 18, 167, 138, 250, 32, 244, 83, 9, 128, 93, 166, 56, 80, 69, 102, 88, 1, 168, 231, 246, 114, 82, 180, 201, 161 }, new byte[] { 245, 178, 223, 104, 196, 239, 62, 170, 146, 76, 8, 90, 28, 224, 182, 88, 53, 246, 98, 188, 212, 113, 61, 238, 34, 214, 251, 233, 31, 59, 57, 248, 243, 2, 129, 12, 81, 20, 37, 168, 13, 129, 40, 186, 250, 12, 147, 49, 161, 114, 68, 254, 65, 29, 67, 156, 166, 86, 255, 186, 62, 34, 24, 97, 57, 228, 7, 75, 155, 101, 223, 8, 97, 68, 21, 142, 8, 190, 241, 218, 94, 238, 130, 102, 188, 119, 190, 89, 28, 96, 121, 92, 11, 153, 119, 113, 175, 155, 108, 175, 117, 107, 103, 123, 200, 234, 119, 190, 99, 225, 13, 203, 147, 58, 210, 130, 75, 22, 71, 102, 23, 178, 196, 142, 155, 222, 215, 163 }, "Admin" });
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
