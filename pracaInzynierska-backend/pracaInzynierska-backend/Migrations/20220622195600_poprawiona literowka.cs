using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class poprawionaliterowka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Context",
                table: "Posts",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Context",
                table: "Comments",
                newName: "Content");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Posts",
                newName: "Context");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "Context");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(715));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1997, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1992, 6, 20, 21, 26, 40, 76, DateTimeKind.Local).AddTicks(746));
        }
    }
}
