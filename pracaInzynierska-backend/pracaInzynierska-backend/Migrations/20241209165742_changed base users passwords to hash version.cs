using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class changedbaseuserspasswordstohashversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 9, 17, 57, 42, 278, DateTimeKind.Local).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 9, 17, 57, 42, 278, DateTimeKind.Local).AddTicks(1830));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 9, 17, 57, 42, 278, DateTimeKind.Local).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 9, 17, 57, 42, 278, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 9, 17, 57, 42, 278, DateTimeKind.Local).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 9, 17, 57, 42, 278, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 9, 17, 57, 42, 278, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 9, 17, 57, 42, 278, DateTimeKind.Local).AddTicks(1726));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 12, 9, 17, 57, 42, 278, DateTimeKind.Local).AddTicks(1727));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "BirthDate", "Password" },
                values: new object[] { new DateTime(2004, 12, 9, 17, 57, 42, 276, DateTimeKind.Local).AddTicks(7325), "59Vrw5YDQ2QrbnB3ArrLUK6nkGhl+cf+V3hG9RuMFuN4HfKnS7ymZu4XEIcCPWuN" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "BirthDate", "Password" },
                values: new object[] { new DateTime(1999, 12, 9, 17, 57, 42, 276, DateTimeKind.Local).AddTicks(7360), "59Vrw5YDQ2QrbnB3ArrLUK6nkGhl+cf+V3hG9RuMFuN4HfKnS7ymZu4XEIcCPWuN" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "BirthDate", "Password" },
                values: new object[] { new DateTime(1994, 12, 9, 17, 57, 42, 276, DateTimeKind.Local).AddTicks(7364), "59Vrw5YDQ2QrbnB3ArrLUK6nkGhl+cf+V3hG9RuMFuN4HfKnS7ymZu4XEIcCPWuN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1411));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1318));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 12, 9, 15, 50, 41, 806, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "BirthDate", "Password" },
                values: new object[] { new DateTime(2004, 12, 9, 15, 50, 41, 804, DateTimeKind.Local).AddTicks(8290), "bedzieHash" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "BirthDate", "Password" },
                values: new object[] { new DateTime(1999, 12, 9, 15, 50, 41, 804, DateTimeKind.Local).AddTicks(8327), "bedzieHash" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "BirthDate", "Password" },
                values: new object[] { new DateTime(1994, 12, 9, 15, 50, 41, 804, DateTimeKind.Local).AddTicks(8330), "bedzieHash" });
        }
    }
}
