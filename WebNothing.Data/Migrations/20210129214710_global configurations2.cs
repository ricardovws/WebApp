using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebNothing.Data.Migrations
{
    public partial class globalconfigurations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 29, 18, 47, 10, 406, DateTimeKind.Local).AddTicks(1540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 29, 18, 19, 34, 134, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 29, 18, 19, 34, 134, DateTimeKind.Local).AddTicks(8242),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 1, 29, 18, 47, 10, 406, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
