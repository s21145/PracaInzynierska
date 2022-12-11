using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class publicNameForStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicName",
                table: "StatsNames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 11, 13, 22, 19, 888, DateTimeKind.Local).AddTicks(92));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 11, 13, 22, 19, 888, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 11, 13, 22, 19, 888, DateTimeKind.Local).AddTicks(106));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 12, 11, 13, 22, 19, 888, DateTimeKind.Local).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicName",
                value: "Kills");

            migrationBuilder.UpdateData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicName",
                value: "Deaths");

            migrationBuilder.UpdateData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicName",
                value: "Headshots");

            migrationBuilder.UpdateData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublicName",
                value: "Wins");

            migrationBuilder.UpdateData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublicName",
                value: "Matches");

            migrationBuilder.UpdateData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublicName",
                value: "Hit Shots");

            migrationBuilder.UpdateData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublicName",
                value: "Fired Shots");

            migrationBuilder.UpdateData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublicName",
                value: "Play Time");

            migrationBuilder.UpdateData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublicName",
                value: "MVP");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 12, 11, 13, 22, 19, 887, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1997, 12, 11, 13, 22, 19, 887, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1992, 12, 11, 13, 22, 19, 887, DateTimeKind.Local).AddTicks(6298));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicName",
                table: "StatsNames");

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
    }
}
