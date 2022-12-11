using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInzynierska_backend.Migrations
{
    public partial class FriendList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FriendLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    FriendId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendLists_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_FriendLists_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 11, 14, 22, 3, 43, DateTimeKind.Local).AddTicks(5877));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 11, 14, 22, 3, 43, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 11, 14, 22, 3, 43, DateTimeKind.Local).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 12, 11, 14, 22, 3, 43, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 12, 11, 14, 22, 3, 43, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1997, 12, 11, 14, 22, 3, 43, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1992, 12, 11, 14, 22, 3, 43, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.CreateIndex(
                name: "IX_FriendLists_FriendId",
                table: "FriendLists",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendLists_OwnerId",
                table: "FriendLists",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendLists");

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
    }
}
