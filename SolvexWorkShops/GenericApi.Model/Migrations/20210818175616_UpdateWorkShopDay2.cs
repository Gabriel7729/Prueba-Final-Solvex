using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericApi.Model.Migrations
{
    public partial class UpdateWorkShopDay2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "StartHour",
                table: "WorkShopDays",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndHour",
                table: "WorkShopDays",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Dob" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 17, 56, 15, 776, DateTimeKind.Unspecified).AddTicks(1713), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 8, 18, 13, 56, 15, 776, DateTimeKind.Local).AddTicks(2353) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartHour",
                table: "WorkShopDays",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndHour",
                table: "WorkShopDays",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Dob" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 16, 47, 58, 664, DateTimeKind.Unspecified).AddTicks(7014), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 8, 18, 12, 47, 58, 664, DateTimeKind.Local).AddTicks(7640) });
        }
    }
}
