using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericApi.Model.Migrations
{
    public partial class UpdateWorkShopDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartHour",
                table: "WorkShopDays",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndHour",
                table: "WorkShopDays",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Dob" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 16, 47, 58, 664, DateTimeKind.Unspecified).AddTicks(7014), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 8, 18, 12, 47, 58, 664, DateTimeKind.Local).AddTicks(7640) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartHour",
                table: "WorkShopDays",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndHour",
                table: "WorkShopDays",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Dob" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 15, 22, 25, 22, 171, DateTimeKind.Unspecified).AddTicks(6651), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 8, 15, 18, 25, 22, 171, DateTimeKind.Local).AddTicks(7309) });
        }
    }
}
