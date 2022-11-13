using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class steamId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconPath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SteamId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 11, 13, 21, 38, 25, 529, DateTimeKind.Local).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 11, 13, 21, 38, 25, 529, DateTimeKind.Local).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 11, 13, 21, 38, 25, 529, DateTimeKind.Local).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 11, 13, 21, 38, 25, 529, DateTimeKind.Local).AddTicks(3774));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "BirthDate", "IconPath" },
                values: new object[] { new DateTime(2002, 11, 13, 21, 38, 25, 529, DateTimeKind.Local).AddTicks(290), "../../images/default.png" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "BirthDate", "IconPath" },
                values: new object[] { new DateTime(1997, 11, 13, 21, 38, 25, 529, DateTimeKind.Local).AddTicks(324), "../../images/default.png" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "BirthDate", "IconPath" },
                values: new object[] { new DateTime(1992, 11, 13, 21, 38, 25, 529, DateTimeKind.Local).AddTicks(327), "../../images/default.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconPath",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SteamId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 9, 1, 19, 7, 58, 665, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 9, 1, 19, 7, 58, 665, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 9, 1, 19, 7, 58, 665, DateTimeKind.Local).AddTicks(5901));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 9, 1, 19, 7, 58, 665, DateTimeKind.Local).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 9, 1, 19, 7, 58, 665, DateTimeKind.Local).AddTicks(1745));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1997, 9, 1, 19, 7, 58, 665, DateTimeKind.Local).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1992, 9, 1, 19, 7, 58, 665, DateTimeKind.Local).AddTicks(1779));
        }
    }
}
