using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericApi.Model.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Dob" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 15, 22, 25, 22, 171, DateTimeKind.Unspecified).AddTicks(6651), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 8, 15, 18, 25, 22, 171, DateTimeKind.Local).AddTicks(7309) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Dob" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 6, 16, 50, 35, 53, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 8, 6, 12, 50, 35, 53, DateTimeKind.Local).AddTicks(8877) });
        }
    }
}
