using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class AddedDataForRust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3519));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(3449));

            migrationBuilder.InsertData(
                table: "StatsNames",
                columns: new[] { "Id", "IdGame", "Name", "PublicName" },
                values: new object[,]
                {
                    { 10, 4, "kill_player", "Kills" },
                    { 11, 4, "deaths", "Deaths" },
                    { 12, 4, "bullet_fired", "Bullet fired" },
                    { 13, 4, "headshot", "Headshots" },
                    { 14, 4, "bullet_hit_player", "Hit Shots Player" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2004, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1999, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1994, 8, 14, 13, 45, 38, 984, DateTimeKind.Local).AddTicks(1421));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StatsNames",
                keyColumn: "Id",
                keyValue: 14);

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

            migrationBuilder.InsertData(
                table: "StatsNames",
                columns: new[] { "Id", "IdGame", "Name", "PublicName" },
                values: new object[] { 8, 1, "total_time_played", "Play Time" });

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
    }
}
