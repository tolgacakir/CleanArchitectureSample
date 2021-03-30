using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample.Persistence.Migrations
{
    public partial class Migration_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 26, 17, 4, 7, 715, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 26, 17, 4, 7, 717, DateTimeKind.Local).AddTicks(1528));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 26, 16, 57, 18, 968, DateTimeKind.Local).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 26, 16, 57, 18, 969, DateTimeKind.Local).AddTicks(9488));
        }
    }
}
