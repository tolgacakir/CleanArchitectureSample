using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample.Persistence.Migrations
{
    public partial class Migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Created", "CreatedBy", "DisplayName", "Email", "LastModified", "LastModifiedBy", "Password", "UserName" },
                values: new object[] { 1, new DateTime(2021, 3, 19, 17, 48, 52, 666, DateTimeKind.Local).AddTicks(7046), "admin", "Tolga Çakır", "tolgacakirx@gmail.com", null, null, "123", "tolgacakir" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Created", "CreatedBy", "DisplayName", "Email", "LastModified", "LastModifiedBy", "Password", "UserName" },
                values: new object[] { 2, new DateTime(2021, 3, 19, 17, 48, 52, 667, DateTimeKind.Local).AddTicks(7880), "admin", "USER 2", "user2@gmail.com", null, null, "123", "user2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
