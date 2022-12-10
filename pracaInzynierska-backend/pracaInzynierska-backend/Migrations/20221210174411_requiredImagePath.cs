using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class requiredImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 10, 18, 44, 11, 349, DateTimeKind.Local).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 10, 18, 44, 11, 349, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 10, 18, 44, 11, 349, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 12, 10, 18, 44, 11, 349, DateTimeKind.Local).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 12, 10, 18, 44, 11, 349, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1997, 12, 10, 18, 44, 11, 349, DateTimeKind.Local).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1992, 12, 10, 18, 44, 11, 349, DateTimeKind.Local).AddTicks(6221));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 10, 18, 43, 30, 128, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 10, 18, 43, 30, 128, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 10, 18, 43, 30, 128, DateTimeKind.Local).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 12, 10, 18, 43, 30, 128, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 12, 10, 18, 43, 30, 127, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1997, 12, 10, 18, 43, 30, 127, DateTimeKind.Local).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1992, 12, 10, 18, 43, 30, 127, DateTimeKind.Local).AddTicks(8767));
        }
    }
}
