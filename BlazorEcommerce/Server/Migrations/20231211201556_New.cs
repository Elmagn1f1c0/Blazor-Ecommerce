using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 12, 11, 21, 15, 56, 463, DateTimeKind.Local).AddTicks(1589), new byte[] { 1, 0, 0, 0, 1, 0, 0, 39, 16, 0, 0, 0, 16, 74, 60, 213, 105, 25, 144, 102, 238, 100, 104, 182, 208, 27, 186, 121, 235, 91, 77, 89, 13, 91, 34, 140, 229, 154, 96, 155, 83, 87, 126, 159, 180, 51, 26, 209, 42, 147, 16, 255, 201, 80, 226, 88, 81, 18, 129, 111, 250 }, new byte[] { 203, 244, 58, 65, 54, 119, 17, 233, 54, 19, 154, 202, 79, 104, 20, 75 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 12, 11, 21, 5, 20, 77, DateTimeKind.Local).AddTicks(2014), new byte[] { 1, 0, 0, 0, 1, 0, 0, 39, 16, 0, 0, 0, 16, 169, 123, 251, 58, 59, 192, 172, 238, 25, 102, 133, 166, 209, 76, 34, 10, 102, 2, 125, 175, 96, 181, 66, 90, 203, 227, 72, 34, 0, 174, 67, 244, 62, 245, 204, 210, 115, 157, 143, 250, 121, 13, 25, 143, 244, 17, 200, 68 }, new byte[] { 100, 26, 233, 218, 22, 24, 191, 120, 95, 212, 201, 69, 180, 4, 158, 86 } });
        }
    }
}
