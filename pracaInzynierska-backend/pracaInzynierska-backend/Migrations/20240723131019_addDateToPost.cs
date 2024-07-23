using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class addDateToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(8688));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(8706));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2004, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1999, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1994, 7, 23, 15, 10, 18, 805, DateTimeKind.Local).AddTicks(5557));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 5, 20, 19, 47, 14, 686, DateTimeKind.Local).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 5, 20, 19, 47, 14, 686, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 20, 19, 47, 14, 686, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 5, 20, 19, 47, 14, 686, DateTimeKind.Local).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2004, 5, 20, 19, 47, 14, 686, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1999, 5, 20, 19, 47, 14, 686, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1994, 5, 20, 19, 47, 14, 686, DateTimeKind.Local).AddTicks(3573));
        }
    }
}
