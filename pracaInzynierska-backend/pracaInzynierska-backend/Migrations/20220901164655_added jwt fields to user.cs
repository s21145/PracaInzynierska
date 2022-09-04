using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class addedjwtfieldstouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentRefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExp",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 9, 1, 18, 46, 54, 761, DateTimeKind.Local).AddTicks(6901));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 9, 1, 18, 46, 54, 761, DateTimeKind.Local).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 9, 1, 18, 46, 54, 761, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 9, 1, 18, 46, 54, 761, DateTimeKind.Local).AddTicks(6917));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 9, 1, 18, 46, 54, 761, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1997, 9, 1, 18, 46, 54, 761, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1992, 9, 1, 18, 46, 54, 761, DateTimeKind.Local).AddTicks(2538));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentRefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExp",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 6, 22, 21, 55, 59, 918, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 6, 22, 21, 55, 59, 918, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 6, 22, 21, 55, 59, 918, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 6, 22, 21, 55, 59, 918, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 6, 22, 21, 55, 59, 918, DateTimeKind.Local).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1997, 6, 22, 21, 55, 59, 918, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1992, 6, 22, 21, 55, 59, 918, DateTimeKind.Local).AddTicks(4845));
        }
    }
}
